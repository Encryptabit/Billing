using Billing.Application;
using Billing.Application.Interfaces;
using Billing.Infrastructure;
using Billing.Presentation.UI.Components;
using Hangfire;
using Hangfire.Dashboard;
using Microsoft.FluentUI.AspNetCore.Components;

var builder = WebApplication.CreateBuilder(args);

builder.Host.UseWindowsService();

// builder.Configuration.AddUserSecrets<Program>();
builder.Configuration.AddEnvironmentVariables("AutoCrib:");

// Add Services to the container
builder.Services.AddWindowsService(options => options.ServiceName = "AutoCrib.Billing");
builder.Services.AddApplication();
builder.Services.AddInfrastructure(builder.Configuration);

builder.WebHost.UseKestrel((context, serverOptions) =>
{
    //serverOptions.Configure(context.Configuration.GetSection("Kestrel"))
    //.Endpoint("HTTPS", listenOptions =>
    //{
    //    listenOptions.HttpsOptions.SslProtocols = System.Security.Authentication.SslProtocols.Tls12;
    //});
}); 

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddFluentUIComponents();
builder.Services.AddDataGridEntityFrameworkAdapter();

var app = builder.Build();

//Hangfire UI
app.UseHangfireDashboard("/jobs", new DashboardOptions()
{
    AppPath = null,
    Authorization = [new DashboardAuthFilter()]
});

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
}

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
