namespace WebUI.Configuration
{
    public class AdminConfiguration
    {
        public string ClientId { get; set; } = string.Empty;
        public string ClientSecret { get; set; } = string.Empty;

        public int IdentityAdminCookieExpiresUtcMinutes { get; set; } = 30;
        public string IdentityAdminCookieName { get; set; } = "IdentityServerAdmin";

        public string IdentityAdminRedirectUri { get; set; } = string.Empty;
        public string RedirectUri { get; set; } = string.Empty;
        public string IdentityServerBaseUrl { get; set; } = string.Empty;
        public string OidcResponseType { get; set; } = "code";
        public bool RequireHttpsMetadata { get; set; } = false;

        public string[] Scopes { get; set; } = new[] { "openid", "profile", "email" };

        public string TokenValidationClaimName { get; set; } = "name";
        public string TokenValidationClaimRole { get; set; } = "role";
    }
}
