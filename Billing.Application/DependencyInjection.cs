using Billing.Application.UseCases.Billing;
using Billing.Application.UseCases.Organizations;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace Billing.Application;

public static class DependencyInjection
{
   public static IServiceCollection AddApplication(this IServiceCollection services)
   {
       // services.AddScoped<IUpdateArcturusTypeCommandHandler, UpdateArcturusTypeCommandHandler>();
       services.AddScoped<IGetWorkOSConnectionsQueryHandler, GetWorkOSConnectionsQueryHandler>();
       services.AddScoped<IGetConstructedOrganizationsQueryHandler, GetConstructedOrganizationsQueryHandler>();
       services.AddScoped<IGetIdentityServerRestApiConnectionsQueryHandler, GetIdentityServerRestApiConnectionsQueryHandler>();
       services.AddScoped<IGetBillingHistoryQueryHandler, GetBillingHistoryQueryHandler>();
       services.AddScoped<IGetDatabasesQueryHandler, GetDatabasesQueryHandler>();
       services.AddScoped<IGetDistributorEndUsersQueryHandler, GetDistributorEndUsersQueryHandler>();
       services.AddScoped<IGetDistributorsQueryHandler, GetDistributorsQueryHandler>();
       services.AddScoped<IGetEndUserDatabasesQueryHandler, GetEndUserDatabasesQueryHandler>();
       services.AddScoped<IGetEndUsersQueryHandler, GetEndUsersQueryHandler>();
       services.AddScoped<IGetOrganizationsQueryHandler, GetOrganizationsQueryHandler>();
       
       return services;
   }
}