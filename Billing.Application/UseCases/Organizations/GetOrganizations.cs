using Billing.Application.Interfaces;
using Billing.Domain.Entities;
using MediatR;

namespace Billing.Application.UseCases.Organizations;

// The Queries
public record GetAllOrganizationsQuery : IRequest<IEnumerable<Organization>>;
public record GetOrganizationBySsoOrganizationIdQuery(Organization Organization) :  IRequest<Organization>;

// The Interfaces for DI
public interface IGetOrganizationsQueryHandler
{
    Task<IEnumerable<Organization>> Handle(GetAllOrganizationsQuery request, CancellationToken cancellationToken);
}


public interface IGetOrganizationBySsoOrganizationIdQueryHandler
{
    Task<Organization> Handle(GetOrganizationBySsoOrganizationIdQuery request, CancellationToken cancellationToken);
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

public class GetOrganizationBySsoOrganizationIdQueryHandler(
    IOrganizationCacheServices organizationCacheServices) : 
    IRequestHandler<GetOrganizationBySsoOrganizationIdQuery, 
        Organization>,
    IGetOrganizationBySsoOrganizationIdQueryHandler
{
    public async Task<Organization> Handle(GetOrganizationBySsoOrganizationIdQuery request, CancellationToken cancellationToken)
    {
        return await organizationCacheServices.GetOrganizationBySsoOrganizationIdAsync(request.Organization);
    }
}
