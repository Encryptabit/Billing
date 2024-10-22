using Billing.Application;
using Billing.Infrastructure;
using Billing.Presentation.UI.Components;

var builder = WebApplication.CreateBuilder(args);

builder.Host.UseWindowsService();

builder.Configuration.AddUserSecrets<Program>();

// Add Services to the container
builder.Services.AddWindowsService(options => options.ServiceName = "Billing Processor");
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

var app = builder.Build();

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
