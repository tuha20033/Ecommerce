using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using WebPortal.Grpc.Contracts.Helpers;
using WebUI.Configuration;
using NWebsec.AspNetCore.Middleware;
namespace WebUI.Helpers
{
    public static class StartupHelpers
    {
        /// <summary>
        /// Register services for authentication, including Identity.
        /// For production mode is used OpenId Connect middleware which is connected to IdentityServer4 instance.
        /// For testing purpose is used cookie middleware with fake login url.
        /// </summary>
        /// <typeparam name="TContext"></typeparam>
        /// <typeparam name="TUserIdentity"></typeparam>
        /// <typeparam name="TUserIdentityRole"></typeparam>
        /// <param name="services"></param>
        /// <param name="adminConfiguration"></param>
        public static void AddAuthenticationServices<TContext, TUserIdentity, TUserIdentityRole>(this IServiceCollection services,
            AdminConfiguration adminConfiguration, Action<IdentityOptions> identityOptionsAction, Action<AuthenticationBuilder> authenticationBuilderAction)
            where TContext : DbContext where TUserIdentity : class where TUserIdentityRole : class
        {
            //services.AddMvc();
            services.Configure<CookiePolicyOptions>(options =>
            {
                options.MinimumSameSitePolicy = SameSiteMode.Unspecified;
                options.Secure = CookieSecurePolicy.SameAsRequest;
                options.OnAppendCookie = cookieContext =>
                    AuthenticationHelpers.CheckSameSite(cookieContext.Context, cookieContext.CookieOptions);
                options.OnDeleteCookie = cookieContext =>
                    AuthenticationHelpers.CheckSameSite(cookieContext.Context, cookieContext.CookieOptions);
            });

            services
                .AddIdentity<TUserIdentity, TUserIdentityRole>(identityOptionsAction)
                .AddEntityFrameworkStores<TContext>()
                .AddDefaultTokenProviders();

            services.AddAuthentication(options =>
            {
                options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = OpenIdConnectDefaults.AuthenticationScheme;

                options.DefaultAuthenticateScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                options.DefaultForbidScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                options.DefaultSignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                options.DefaultSignOutScheme = CookieAuthenticationDefaults.AuthenticationScheme;
            })
                    .AddCookie(CookieAuthenticationDefaults.AuthenticationScheme,
                        options =>
                        {
                            options.Cookie.Name = adminConfiguration.IdentityAdminCookieName;
                            options.ExpireTimeSpan = TimeSpan.FromMinutes(adminConfiguration.IdentityAdminCookieExpiresUtcMinutes);
                            options.AccessDeniedPath = "/403";
                        })
                    .AddOpenIdConnect(OpenIdConnectDefaults.AuthenticationScheme, options =>
                    {
                        options.Authority = adminConfiguration.IdentityServerBaseUrl;
                        options.RequireHttpsMetadata = adminConfiguration.RequireHttpsMetadata;
                        options.ClientId = adminConfiguration.ClientId;
                        options.ClientSecret = adminConfiguration.ClientSecret;
                        options.ResponseType = adminConfiguration.OidcResponseType;
                        options.Scope.Add("roles");
                        // 

                        options.SaveTokens = false;
                        options.Events = new OpenIdConnectEvents
                        {
                            OnTokenResponseReceived = async x =>
                            {
                                x.Properties!.StoreTokens([ new AuthenticationToken
                            {
                                Name = "id_token",
                                Value = x.TokenEndpointResponse.IdToken
                            }]);

                                await Task.CompletedTask;
                            },
                            OnMessageReceived = context => OnMessageReceived(context, adminConfiguration),
                            OnRedirectToIdentityProvider = context => OnRedirectToIdentityProvider(context, adminConfiguration),

                            OnTokenValidated = async context =>
                            {
                                // Lấy token từ context
                                var accessToken = context.TokenEndpointResponse?.AccessToken;
                                var refreshToken = context.TokenEndpointResponse?.RefreshToken;
                                _ = int.TryParse(context.TokenEndpointResponse?.ExpiresIn, out var expiresIn);
                                _ = int.TryParse(context.TokenEndpointResponse?.Parameters["refresh_expires_in"], out var refresh_expires_in);
                                // Lấy IServiceProvider từ HttpContext
                                var serviceProvider = context.HttpContext.RequestServices;

                                // Lấy service từ DI container
                                var tokenService = serviceProvider.GetRequiredService<ITokenProvider>();

                                // Lưu trữ token vào store riêng (VD: cơ sở dữ liệu, Redis, file, ...)
                                var setAccessToken = tokenService.SetAsync($"{context.Principal?.Identity?.Name}:access_token", accessToken, TimeSpan.FromSeconds(expiresIn));
                                var setRefreshToken = tokenService.SetAsync($"{context.Principal?.Identity?.Name}:refresh_token", refreshToken, TimeSpan.FromSeconds(refresh_expires_in));
                                await Task.WhenAll(setAccessToken, setRefreshToken);
                                //await SaveTokenToCustomStore(accessToken, refreshToken);
                                // Tiếp tục quá trình xử lý
                                return;
                            },
                        };
                        options.BackchannelHttpHandler = new HttpClientHandler()
                        {
                            ServerCertificateCustomValidationCallback = HttpClientHandler.DangerousAcceptAnyServerCertificateValidator
                        };
                    });

            //authenticationBuilderAction?.Invoke(authenticationBuilder);
        }


        private static Task OnMessageReceived(MessageReceivedContext context, AdminConfiguration adminConfiguration)
        {
            context.Properties.IsPersistent = true;
            context.Properties.ExpiresUtc = DateTimeOffset.UtcNow.AddMinutes(adminConfiguration.IdentityAdminCookieExpiresUtcMinutes);
            return Task.CompletedTask;
        }

        private static Task OnRedirectToIdentityProvider(RedirectContext context, AdminConfiguration adminConfiguration)
        {
            if (!string.IsNullOrEmpty(adminConfiguration.IdentityAdminRedirectUri))
            {
                context.ProtocolMessage.RedirectUri = adminConfiguration.IdentityAdminRedirectUri;
            }
            return Task.CompletedTask;
        }
        /// <summary>
        /// Using of Forwarded Headers, Hsts, XXssProtection and Csp
        /// </summary>
        /// <param name="app"></param>
        /// <param name="configuration"></param>
        public static void UseSecurityHeaders(this IApplicationBuilder app, List<string> cspTrustedDomains)
        {
            var forwardingOptions = new ForwardedHeadersOptions()
            {
                ForwardedHeaders = ForwardedHeaders.All
            };

            forwardingOptions.KnownNetworks.Clear();
            forwardingOptions.KnownProxies.Clear();

            app.UseForwardedHeaders(forwardingOptions);

            app.UseXXssProtection(options => options.EnabledWithBlockMode());
            app.UseXContentTypeOptions();
            app.UseXfo(options => options.SameOrigin());
            app.UseReferrerPolicy(options => options.NoReferrer());

            // CSP Configuration to be able to use external resources
            if (cspTrustedDomains != null && cspTrustedDomains.Count != 0)
            {
                app.UseCsp(csp =>
                {
                    var imagesCustomSources = new List<string>();
                    imagesCustomSources.AddRange(cspTrustedDomains);
                    imagesCustomSources.Add("data:");

                    csp.ImageSources(options =>
                    {
                        options.SelfSrc = true;
                        options.CustomSources = imagesCustomSources;
                        options.Enabled = true;
                    });
                    csp.FontSources(options =>
                    {
                        options.SelfSrc = true;
                        options.CustomSources = cspTrustedDomains;
                        options.Enabled = true;
                    });
                    csp.ScriptSources(options =>
                    {
                        options.SelfSrc = true;
                        options.CustomSources = cspTrustedDomains;
                        options.Enabled = true;
                        options.UnsafeInlineSrc = true;
                        options.UnsafeEvalSrc = true;
                    });
                    csp.StyleSources(options =>
                    {
                        options.SelfSrc = true;
                        options.CustomSources = cspTrustedDomains;
                        options.Enabled = true;
                        options.UnsafeInlineSrc = true;
                    });
                    csp.DefaultSources(options =>
                    {
                        options.SelfSrc = true;
                        options.CustomSources = cspTrustedDomains;
                        options.Enabled = true;
                    });
                });
            }
        }

        public static void UseCommonMiddleware(this IApplicationBuilder app, SecurityConfiguration securityConfiguration)
        {
            app.UseCookiePolicy();
            // Add custom security headers
            //app.UseSecurityHeaders(securityConfiguration.CspTrustedDomains);
            app.UseStaticFiles();
        }

        public static AuthenticationProperties GetAuthProperties(string? returnUrl)
        {
            // TODO: Use HttpContext.Request.PathBase instead.
            const string pathBase = "/";

            // Prevent open redirects.
            if (string.IsNullOrEmpty(returnUrl))
            {
                returnUrl = pathBase;
            }
            else if (!Uri.IsWellFormedUriString(returnUrl, UriKind.Relative))
            {
                returnUrl = new Uri(returnUrl, UriKind.Absolute).PathAndQuery;
            }
            else if (returnUrl[0] != '/')
            {
                returnUrl = $"{pathBase}{returnUrl}";
            }

            return new AuthenticationProperties { RedirectUri = returnUrl };
        }

    }
}