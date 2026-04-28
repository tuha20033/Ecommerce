using Application;
using Application.Abstractions.Repositories;
using Application.Services;
using Infrastructure.Extentions;
using Infrastructure.Repositories;
using Infrastructure.Services;
using MudBlazor.Services;
using WebUI.Components;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddMudServices();
builder.Services.AddApplication();

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();
builder.Services.AddWebPortalInfrastructure(builder.Configuration);
builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
builder.Services.AddHttpClient("keycloak", client =>
{
    client.BaseAddress = new Uri(builder.Configuration["Keycloak:Authority"]!);
});

// Đăng ký Service
builder.Services.AddScoped<IKeycloakUserService, KeyCloakUserService>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
