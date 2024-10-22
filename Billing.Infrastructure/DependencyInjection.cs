using Billing.Application.Interfaces;
using Billing.Infrastructure.ExternalServices;
using Billing.Infrastructure.Persistence;
using Microsoft.Extensions.DependencyInjection;
using WorkOS;

namespace Billing.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        services.AddScoped<IBillingRepository, BillingRepository>();
        services.AddScoped<IDatabasesRepository, DatabasesRepository>();
        services.AddScoped<IOrganizationsRepository, OrganizationsRepository>();
        services.AddHttpClient();
        
        // Register External Services and other infra related dependencies
        services.AddScoped<SSOService>();
        services.AddScoped<IWorkOSService, WorkOSService>();
        services.AddScoped<IIdentityServerService ,IdentityServerService>();
        
        return services;
    }
}