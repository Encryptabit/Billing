using Billing.Application.Interfaces;
using Microsoft.Extensions.Caching.Memory;
using WorkOS;

namespace Billing.Infrastructure.Caching;

// TODO: Implement the Repository behavior in here as well
public class OrganizationCacheServices(
    IWorkOSService _workOsService,
    IIdentityServerService _identityServerService,
    IMemoryCache _cache) : IOrganizationCacheServices
{
    private static int _cacheHits = 0;
    private static int _cacheMisses = 0;
    private string GetInternalOrgIdCacheKey(int organizationId) => $"internal_org_{organizationId}";
    
    public async Task<WorkOSList<Connection>> GetWorkOSConnectionsAsync()
    {
        if (!_cache.TryGetValue("SSOOrganizations", out WorkOSList<Connection> connections))
        {
           Interlocked.Increment(ref _cacheMisses);
           
           // async fetch workos api
           connections = await _workOsService.FetchWorkOSConnectionsAsync();
           
           _cache.Set("SSOConnections", connections);
        }
        else
        {
            Interlocked.Increment(ref _cacheHits);
        }

        return connections;
    }

    public async Task<List<int>> GetRestApiConnectionsAsync()
    {
        if (!_cache.TryGetValue("RestApiConnections", out List<int> restApiConnections))
        {
            Interlocked.Increment(ref _cacheMisses);
            restApiConnections = await _identityServerService.FetchRestApiConnectionsAsync();
            
            _cache.Set("RestApiConnections", restApiConnections);
        }
        else
        {
            Interlocked.Increment(ref _cacheHits);
        }
        
        return restApiConnections;
    }    
    
    // Different ways to get an Orgnization for processes later down the road
    #region Get Organizations
    public async Task<Dictionary<int, Organization>> GetOrganizationByIdAsync(int organizationId)
    {
        return new Dictionary<int, Organization>();
    }

    public async Task<Dictionary<int, Organization>> GetOrganizationByDbIdAsync(int dbId)
    {
        return new Dictionary<int, Organization>();
    }

    public async Task<Dictionary<string, Organization>> GetOrganizationBySSOOrganizationIdAsync(string userId)
    {
        return new Dictionary<string, Organization>();
    }
    #endregion
}