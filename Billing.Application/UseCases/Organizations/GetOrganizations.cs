using Billing.Application.Interfaces;
using Billing.Domain.Entities;
using Billing.Domain.Entities.Dto;
using MediatR;

namespace Billing.Application.UseCases.Organizations;

// The Queries
public record GetAllOrganizationsQuery(bool rebuildCache) : IRequest<IEnumerable<OrganizationDto>>;
public record GetSpecificOrganization(OrganizationDto Organization) :  IRequest<OrganizationDto>;

// The Interfaces for DI
public interface IGetOrganizationsQueryHandler
{
    Task<IEnumerable<OrganizationDto>> Handle(GetAllOrganizationsQuery request, CancellationToken cancellationToken);
}

public interface IGetSpecificOrganizationQueryHandler
{
    Task<OrganizationDto> Handle(GetSpecificOrganization request, CancellationToken cancellationToken);
}

// The Handlers for the Queries
public class GetOrganizationsQueryHandler(
    IOrganizationCacheServices organizationCacheServices) : 
    IRequestHandler<GetAllOrganizationsQuery, 
                    IEnumerable<OrganizationDto>>, 
    IGetOrganizationsQueryHandler
{
    public async Task<IEnumerable<OrganizationDto>> Handle(GetAllOrganizationsQuery request, CancellationToken cancellationToken)
    {
        return await organizationCacheServices.GetAllOrganizationsAsync(request.rebuildCache, cancellationToken);
    }
}

/*
 * This can bse used to get a specific Distributor or EndUser it's not relegated to just "Organization"
 * GetDistribitor and GetEndUser will extend this function.
 */
public class GetSpecificOrganizationQueryHandler(
    IOrganizationCacheServices organizationCacheServices) : 
    IRequestHandler<GetSpecificOrganization, 
        OrganizationDto>,
    IGetSpecificOrganizationQueryHandler
{
    public async Task<OrganizationDto> Handle(GetSpecificOrganization request, CancellationToken cancellationToken)
    {
        return await organizationCacheServices.GetSpecificOrganizationAsync(request.Organization, cancellationToken);
    }
}
