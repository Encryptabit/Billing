﻿using Billing.Application.Interfaces;
using Billing.Infrastructure.Caching;
using Billing.Infrastructure.ExternalServices;
using Billing.Infrastructure.Persistence;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WorkOS;

namespace Billing.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<IBillingRepository, BillingRepository>();
        services.AddScoped<IDatabasesRepository, DatabasesRepository>();
        services.AddScoped<IOrganizationsRepository, OrganizationsRepository>();
        services.AddHttpClient();

        // Register External Services and other infra related dependencies
        services.AddScoped<SSOService>();
        services.AddScoped<IWorkOSService>(sp =>
        {
            var apiKey = configuration["WorkOs:ApiKey"];

            return new WorkOSService(apiKey, sp.GetService<SSOService>());
        });
        services.AddScoped<IIdentityServerService ,IdentityServerService>();
        services.AddSingleton<IMemoryCache, MemoryCache>();
        services.AddScoped<IOrganizationCacheServices, OrganizationCacheServices>();
        
        return services;
    }
}