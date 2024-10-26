using Billing.Application.UseCases.Organizations;
using Microsoft.Extensions.DependencyInjection;

namespace Billing.Application;

public static class DependencyInjection
{
   public static IServiceCollection AddApplication(this IServiceCollection services)
   {
       // services.AddScoped<IUpdateArcturusTypeCommandHandler, UpdateArcturusTypeCommandHandler>();
       services.AddScoped<IGetWorkOSConnectionsQueryHandler, GetWorkOSConnectionsQueryHandler>();
       services.AddScoped<IGetIdentityServerRestApiConnectionsQueryHandler, GetIdentityServerRestApiConnectionsQueryHandler>();
       services.AddScoped<IGetOrganizationsQueryHandler, GetOrganizationsQueryHandler>();
       //services.AddMediatR(Assembly.GetExecutingAssembly());
       
       return services;
   }
}