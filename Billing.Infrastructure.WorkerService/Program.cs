using Billing.Infrastructure.WorkerService;

var builder = Host.CreateApplicationBuilder(args);

builder.Services.AddWindowsService(options => options.ServiceName = "Billing Service");

builder.Services.AddHostedService<Worker>();

var host = builder.Build();
host.Run();
