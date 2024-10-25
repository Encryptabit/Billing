using System.Data;
using System.Reflection;
using Billing.Application.UseCases.Billing;
using Billing.Application.UseCases.Organizations;
using Microsoft.Extensions.DependencyInjection;

namespace Billing.Application;

public static class DependencyInjection
{
   public static IServiceCollection AddApplication(this IServiceCollection services)
   {
       // services.AddScoped<IUpdateArcturusTypeCommandHandler, UpdateArcuturusTypeCommandHandler>();
       services.AddScoped<IGetWorkOSConnectionsQueryHandler, GetWorkOSConnectionsQueryHandler>();
       //services.AddMediatR(Assembly.GetExecutingAssembly());
       
       return services;
   }
}