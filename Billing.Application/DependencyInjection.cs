using System.Data;
using Billing.Application.UseCases.Billing;
using Microsoft.Extensions.DependencyInjection;

namespace Billing.Application;

public static class DependencyInjection
{
   public static IServiceCollection AddApplication(this IServiceCollection services)
   {
       // services.AddScoped<IUpdateArcturusTypeCommandHandler, UpdateArcuturusTypeCommandHandler>();
    
       return services;
   }
}