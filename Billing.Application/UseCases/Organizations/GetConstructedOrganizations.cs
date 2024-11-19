using Billing.Application.Interfaces;
using Billing.Domain.Entities;
using MediatR;

namespace Billing.Application.UseCases.Organizations;

public record GetConstructedOrganizationsQuery(bool rebuildCache) : IRequest<IEnumerable<Organization>>;

public interface IGetConstructedOrganizationsQueryHandler
{
    Task<IEnumerable<Organization>> Handle(GetConstructedOrganizationsQuery request, CancellationToken cancellationToken);
}

public class GetConstructedOrganizationsQueryHandler(
    IOrganizationCacheServices organizationCacheServices) : IRequestHandler<GetConstructedOrganizationsQuery, IEnumerable<Organization>>, IGetConstructedOrganizationsQueryHandler
{
    public async Task<IEnumerable<Organization>> Handle(GetConstructedOrganizationsQuery request, CancellationToken cancellationToken)
    {
       return await organizationCacheServices.GetConstructedOrganizationsAsync(rebuildCache: request.rebuildCache); 
    }
}