using WorkOS;

namespace Billing.Application.Interfaces;

public interface IOrganizationCacheServices
{
    Task<WorkOSList<Connection>> GetWorkOSConnectionsAsync(bool rebuildCache, CancellationToken cancellationToken);
    Task<List<int>> GetRestApiConnectionsAsync(bool rebuildCache, CancellationToken cancellationToken);
    // Task<Dictionary<int, Organization>> GetOrganizationByIdAsync(int organizationId);
    // Task<Dictionary<int, Organization>> GetOrganizationByDbIdAsync(int dbId);
    Task<Domain.Entities.Organization> GetOrganizationBySsoOrganizationIdAsync(Domain.Entities.Organization organization);
    Task<List<Domain.Entities.Organization>> GetAllOrganizationsAsync();
}