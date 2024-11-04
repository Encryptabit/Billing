using Billing.Application.Interfaces;
using Billing.Domain.Entities;
using Billing.Domain.Entities.Dto;
using Billing.Infrastructure.Persistence;
using Microsoft.Extensions.Caching.Memory;
using WorkOS;

namespace Billing.Infrastructure.Caching;

// TODO: Implement the Repository behavior in here as well
internal class OrganizationCacheServices(
    IWorkOSService _workOsService,
    IIdentityServerService _identityServerService,
    IBillingRepository _billingRepository,
    IDatabasesRepository _databasesRepository,
    IDistributorEndUserRepository _distributorEndUserRepository,
    IDistributorsRepository _distributorsRepository,
    IEndUserDatabaseRepository _endUserDatabaseRepository,
    IEndUsersRepository _endUsersRepository,
    IOrganizationsRepository _organizationsRepository,
    IMemoryCache _cache) : IOrganizationCacheServices
{
    private static int _cacheHits = 0;
    private static int _cacheMisses = 0;
    private string GetInternalOrgIdCacheKey(int organizationId) => $"internal_org_{organizationId}";

    public async Task<WorkOSList<Connection>> GetWorkOSConnectionsAsync(bool rebuildCache = false,
        CancellationToken cancellationToken = default)
    {
        if (rebuildCache || !_cache.TryGetValue("SSOConnections", out WorkOSList<Connection> connections))
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

    public async Task<List<int>> GetRestApiConnectionsAsync(bool rebuildCache = false,
        CancellationToken cancellationToken = default)
    {
        if (rebuildCache || !_cache.TryGetValue("RestApiConnections", out List<int> restApiConnections))
        {
            Interlocked.Increment(ref _cacheMisses);
            restApiConnections =
                await _identityServerService.FetchRestApiConnectionsAsync(rebuildCache, cancellationToken);

            _cache.Set("RestApiConnections", restApiConnections, TimeSpan.FromHours(1));
        }
        else
        {
            Interlocked.Increment(ref _cacheHits);
        }

        return restApiConnections;
    }
    

    // BillingHistory
    #region BillingHistory
    public async Task<List<BillingDto>> GetAllBillingHistoryAsync(bool rebuildCache = false,
        CancellationToken cancellationToken = default)
    {
        if (rebuildCache || !_cache.TryGetValue("BillingHistoryDtos", out List<BillingDto> billingDtos))
        {
            Interlocked.Increment(ref _cacheMisses);
            billingDtos =
                await _billingRepository.GetAllAsync();

            _cache.Set("BillingHistoryDtos", billingDtos, TimeSpan.FromHours(1));
        }
        else
        {
            Interlocked.Increment(ref _cacheHits);
        }

        return billingDtos;
    }
    public Task<List<BillingDto>> GetSpecificOrganizationsBillingHistoryAsync(OrganizationDto organization, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    #endregion
    
    // Database
    #region Database
    public async Task<List<DatabaseDto>> GetAllDatabasesAsync(bool rebuildCache = false,
        CancellationToken cancellationToken = default)
    {
        if (rebuildCache || !_cache.TryGetValue("DatabaseDtos", out List<DatabaseDto> databaseDtos))
        {
            Interlocked.Increment(ref _cacheMisses);
            databaseDtos =
                await _databasesRepository.GetAllAsync();

            _cache.Set("DatabaseDtos", databaseDtos, TimeSpan.FromHours(1));
        }
        else
        {
            Interlocked.Increment(ref _cacheHits);
        }

        return databaseDtos;
    }
    public Task<DatabaseDto> GetSpecificDatabaseAsync(OrganizationDto organization, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }
    #endregion
    
    // DistributorEndUser 
    #region DistributorEndUser
    public async Task<List<DistributorEndUserDto>> GetAllDistributorEndUsersAsync(bool rebuildCache = false,
        CancellationToken cancellationToken = default)
    {
        if (rebuildCache || !_cache.TryGetValue("DistributorEndUsersDtos", out List<DistributorEndUserDto> distributorEndUserDtos))
        {
            Interlocked.Increment(ref _cacheMisses);
            distributorEndUserDtos =
                await _distributorEndUserRepository.GetAllAsync();

            _cache.Set("DistributorEndUserDtos", distributorEndUserDtos,TimeSpan.FromHours(1));
        }
        else
        {
            Interlocked.Increment(ref _cacheHits);
        }

        return distributorEndUserDtos;
    }
    public Task<DistributorEndUserDto> GetSpecificDistributorEndUserAsync(OrganizationDto organization, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }
    #endregion
    
    // Distributors
    #region Distributors
    public Task<List<DistributorDto>> GetAllDistributorsAsync(bool rebuildCache = false,
        CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task<DistributorDto> GetSpecificDistributorAsync(DistributorDto distributor)
    {
        throw new NotImplementedException();
    }
    #endregion
    
    // EndUserDatabase
    #region EndUserDatabase
    public async Task<List<EndUserDatabaseDto>> GetAllEndUserDatabasesAsync(bool rebuildCache = false,
        CancellationToken cancellationToken = default)
    {
        if (rebuildCache || !_cache.TryGetValue("EndUserDatabaseDtos", out List<EndUserDatabaseDto> endUserDatabaseDtos))
        {
            Interlocked.Increment(ref _cacheMisses);
            endUserDatabaseDtos =
                await _endUserDatabaseRepository.GetAllAsync();

            _cache.Set("EndUserDatabaseDtos", endUserDatabaseDtos, TimeSpan.FromHours(1));
        }
        else
        {
            Interlocked.Increment(ref _cacheHits);
        }

        return endUserDatabaseDtos;
    }
    public Task<EndUserDatabaseDto> GetSpecificEndUserDatabaseAsync(OrganizationDto organization, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    #endregion

    // End Users
    #region EndUsers
    public async Task<List<EndUserDto>> GetAllEndUsersAsync(bool rebuildCache = false,
        CancellationToken cancellationToken = default)
    {
        if (rebuildCache || !_cache.TryGetValue("EndUserDtos", out List<EndUserDto> endUserDtos))
        {
            Interlocked.Increment(ref _cacheMisses);
            endUserDtos =
                await _endUsersRepository.GetAllAsync();

            _cache.Set("EndUserDtos", endUserDtos, TimeSpan.FromHours(1));
        }
        else
        {
            Interlocked.Increment(ref _cacheHits);
        }

        return endUserDtos;
    }


    public Task<EndUserDto> GetSpecificEndUserAsync(EndUserDto endUser)
    {
        throw new NotImplementedException();
    }

    #endregion
    
    // Different ways to get an Organization for processes later down the road
    #region Organizations
    public async Task<List<OrganizationDto>> GetAllOrganizationsAsync(bool rebuildCache = false,
        CancellationToken cancellationToken = default)
    {
        if (rebuildCache || !_cache.TryGetValue("Organizations", out List<OrganizationDto> organizations))
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
    }

    public async Task<OrganizationDto> GetSpecificOrganizationAsync(OrganizationDto organization,
        CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    #endregion
}