using Billing.Application.Interfaces;
using Microsoft.Extensions.Caching.Memory;
using WorkOS;

namespace Billing.Infrastructure.Caching;

// TODO: Implement the Repository behavior in here as well
public class OrganizationCacheServices(
    IWorkOSService _workOsService,
    IIdentityServerService _identityServerService,
    IOrganizationsRepository _organizationsRepository,
    IMemoryCache _cache) : IOrganizationCacheServices
{
    private static int _cacheHits = 0;
    private static int _cacheMisses = 0;
    private string GetInternalOrgIdCacheKey(int organizationId) => $"internal_org_{organizationId}";
    
    public async Task<WorkOSList<Connection>> GetWorkOSConnectionsAsync(bool rebuildCache = false, CancellationToken cancellationToken = default)
    {
        if (!_cache.TryGetValue("SSOConnections", out WorkOSList<Connection> connections) || rebuildCache)
        {
           Interlocked.Increment(ref _cacheMisses);

           // async fetch workos api
           connections = await _workOsService.FetchWorkOSConnectionsAsync(cancellationToken);
           
           _cache.Set("SSOConnections", connections, TimeSpan.FromHours(1));
        }
        else
        {
            Interlocked.Increment(ref _cacheHits);
        }

        return connections;
    }

    public async Task<List<int>> GetRestApiConnectionsAsync(bool refreshCache = false, CancellationToken cancellationToken = default)
    {
        if (!_cache.TryGetValue("RestApiConnections", out List<int> restApiConnections))
        {
            Interlocked.Increment(ref _cacheMisses);
            restApiConnections = await _identityServerService.FetchRestApiConnectionsAsync(refreshCache, cancellationToken);
            
            _cache.Set("RestApiConnections", restApiConnections, TimeSpan.FromHours(1));
        }
        else
        {
            Interlocked.Increment(ref _cacheHits);
        }
        
        return restApiConnections;
    }

    public async Task<Dictionary<string, Domain.Entities.Organization>> GetOrganizationBySsoOrganizationIdAsync(Domain.Entities.Organization organization)
    {
        throw new NotImplementedException();
    }

    // Different ways to get an Organization for processes later down the road
    #region Get Organizations

    public async Task<List<Billing.Domain.Entities.Organization>> GetAllOrganizationsAsync()
    {
        if (!_cache.TryGetValue("Organizations", out List<Billing.Domain.Entities.Organization> organizations))
        {
            Interlocked.Increment(ref _cacheMisses);
            organizations = await _organizationsRepository.GetAllAsync();
            
            _cache.Set("Organizations", organizations, TimeSpan.FromHours(1));
        }
        else
        {
            Interlocked.Increment(ref _cacheHits);
        }
        
        return organizations;
        ;
    }
    #endregion
}