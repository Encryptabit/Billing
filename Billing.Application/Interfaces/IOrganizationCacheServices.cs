using Billing.Domain.Entities;
using WorkOS;

namespace Billing.Application.Interfaces;

public interface IOrganizationCacheServices
{
    Task<WorkOSList<Connection>> GetWorkOSConnectionsAsync(bool rebuildCache, CancellationToken cancellationToken);
    Task<List<int>> GetRestApiConnectionsAsync(bool rebuildCache, CancellationToken cancellationToken);
    Task<Domain.Entities.Organization> GetSpecificOrganizationAsync(Domain.Entities.Organization organization);
    Task<List<Domain.Entities.Organization>> GetAllOrganizationsAsync();
    Task<List<EndUser>> GetAllEndUsersAsync(CancellationToken cancellationToken);
    Task<EndUser> GetSpecificEndUserAsync(EndUser endUser);
    Task<List<Distributor>> GetAllDistributorsAsync(CancellationToken cancellationToken);
    Task<Distributor> GetSpecificDistributorAsync(Distributor distributor);
}