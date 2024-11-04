using Billing.Application.Interfaces;
using Billing.Domain.Entities;
using MediatR;

namespace Billing.Application.UseCases.Organizations;

// The Queries
public record GetAllOrganizationsQuery : IRequest<IEnumerable<Organization>>;
public record GetSpecificOrganization(Organization Organization) :  IRequest<Organization>;

// The Interfaces for DI
public interface IGetOrganizationsQueryHandler
{
    Task<IEnumerable<Organization>> Handle(GetAllOrganizationsQuery request, CancellationToken cancellationToken);
}


public interface IGetOrganizationBySsoOrganizationIdQueryHandler
{
    Task<Organization> Handle(GetSpecificOrganization request, CancellationToken cancellationToken);
}

// The Handlers for the Queries
public class GetOrganizationsQueryHandler(
    IOrganizationCacheServices organizationCacheServices) : 
    IRequestHandler<GetAllOrganizationsQuery, 
                    IEnumerable<Organization>>, 
    IGetOrganizationsQueryHandler
{
    public async Task<IEnumerable<Organization>> Handle(GetAllOrganizationsQuery request, CancellationToken cancellationToken)
    {
        return await organizationCacheServices.GetAllOrganizationsAsync();
    }
}

/*
 * This can bse used to get a specific Distributor or EndUser it's not relegated to just "Organization"
 * GetDistribitor and GetEndUser will extend this function.
 */
public class GetSpecificOrganizationQueryHandler(
    IOrganizationCacheServices organizationCacheServices) : 
    IRequestHandler<GetSpecificOrganization, 
        Organization>,
    IGetOrganizationBySsoOrganizationIdQueryHandler
{
    public async Task<Organization> Handle(GetSpecificOrganization request, CancellationToken cancellationToken)
    {
        return await organizationCacheServices.GetSpecificOrganizationAsync(request.Organization);
    }
}
