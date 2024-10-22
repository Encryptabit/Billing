using WorkOS;

namespace Billing.Application.Interfaces;

public interface IOrganizationCacheServices
{
    Task<WorkOSList<Connection>> GetWorkOSConnectionsAsync();
    Task<List<int>> GetRestApiConnectionsAsync();
    Task<Dictionary<int, Organization>> GetOrganizationByIdAsync(int organizationId);
    Task<Dictionary<int, Organization>> GetOrganizationByDbIdAsync(int dbId);
    Task<Dictionary<string, Organization>> GetOrganizationBySSOOrganizationIdAsync(string userId);
}