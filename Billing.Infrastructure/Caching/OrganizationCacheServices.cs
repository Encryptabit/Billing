using Billing.Application.Interfaces;
using Billing.Domain.Entities;
using Billing.Domain.Entities.Dto;
using Billing.Infrastructure.Persistence;
using Microsoft.Extensions.Caching.Memory;
using WorkOS;
using Organization = Billing.Domain.Entities.Organization;

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

    public Task<List<BillingDto>> GetSpecificOrganizationsBillingHistoryAsync(OrganizationDto organization,
        CancellationToken cancellationToken = default)
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

    public Task<DatabaseDto> GetSpecificDatabaseAsync(OrganizationDto organization,
        CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    #endregion

    // DistributorEndUser 

    #region DistributorEndUser

    public async Task<List<DistributorEndUserDto>> GetAllDistributorEndUsersAsync(bool rebuildCache = false,
        CancellationToken cancellationToken = default)
    {
        if (rebuildCache || !_cache.TryGetValue("DistributorEndUserDtos",
                out List<DistributorEndUserDto> distributorEndUserDtos))
        {
            Interlocked.Increment(ref _cacheMisses);
            distributorEndUserDtos =
                await _distributorEndUserRepository.GetAllAsync();

            _cache.Set("DistributorEndUserDtos", distributorEndUserDtos, TimeSpan.FromHours(1));
        }
        else
        {
            Interlocked.Increment(ref _cacheHits);
        }

        return distributorEndUserDtos;
    }

    public Task<DistributorEndUserDto> GetSpecificDistributorEndUserAsync(OrganizationDto organization,
        CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    #endregion

    // Distributors

    #region Distributors

    public async Task<List<DistributorDto>> GetAllDistributorsAsync(bool rebuildCache = false,
        CancellationToken cancellationToken = default)
    {
        if (rebuildCache || !_cache.TryGetValue("DistributorDtos", out List<DistributorDto> distributorDtos))
        {
            Interlocked.Increment(ref _cacheMisses);
            distributorDtos =
                await _distributorsRepository.GetAllAsync();

            _cache.Set("DistributorDtos", distributorDtos, TimeSpan.FromHours(1));
        }
        else
        {
            Interlocked.Increment(ref _cacheHits);
        }

        return distributorDtos;
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
        if (rebuildCache ||
            !_cache.TryGetValue("EndUserDatabaseDtos", out List<EndUserDatabaseDto> endUserDatabaseDtos))
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

    public Task<EndUserDatabaseDto> GetSpecificEndUserDatabaseAsync(OrganizationDto organization,
        CancellationToken cancellationToken = default)
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


    #region Custom Structures for Managing Organizations

    public async Task<IEnumerable<Organization>> GetConstructedOrganizationsAsync(bool rebuildCache = false)
    {
        var organizations = new List<Organization>();

        var allPureOrganizations = await GetAllOrganizationsAsync(rebuildCache);
        var allDistributorEndUsers = await GetAllDistributorEndUsersAsync(rebuildCache);
        var allBillingHistory = await GetAllBillingHistoryAsync(rebuildCache);
        var allDistributors = await GetAllDistributorsAsync(rebuildCache);
        var allEndUsers = await GetAllEndUsersAsync(rebuildCache);
        var allDatabases = await GetAllDatabasesAsync(rebuildCache);
        var allEndUserDatabases = await GetAllEndUserDatabasesAsync(rebuildCache);

        // 1. Attach Billing History to Databases
        var processedDatabases = allDatabases.Select(db =>
        {
            var dbSpecificBillingHistory =
                allBillingHistory
                    .OrderByDescending(entry => entry.TimeStamp)
                    .Where(entry => entry.DbId == db.DbId);
            var mostRecentBillingEvent = dbSpecificBillingHistory.FirstOrDefault();
            var activeBill = new Bill(
                billingCycle: mostRecentBillingEvent?.BillingCycle,
                billed: mostRecentBillingEvent?.Billed,
                billDate: mostRecentBillingEvent?.LastBillDate,
                nextBillDate: mostRecentBillingEvent?.NextBillDate,
                lastBillDate: mostRecentBillingEvent?.LastBillDate,
                billedOn: mostRecentBillingEvent?.LastBillDate);

            var billingHistoryDtos = dbSpecificBillingHistory;

            IEnumerable<Domain.Entities.Billing> billingHistories = billingHistoryDtos.Select(entry =>
            {
                return new Domain.Entities.Billing(
                    DbId: entry.DbId,
                    ArcturusType: entry.ArcturusType,
                    BillingCycle: entry.BillingCycle,
                    BillingCycleCustom: entry.BillingCycleCustom,
                    NextBillDate: entry.NextBillDate,
                    LastBillDate: entry.LastBillDate,
                    Vmi: entry.VMI,
                    Billed: entry.Billed,
                    EventId: entry.EventId,
                    TimeStamp: entry.TimeStamp
                );
            });

            var enrichedDb = new Database(
                dbId: db.DbId,
                company: db.Company,
                newAuthentication: db.NewAuthentication,
                bill: activeBill,
                billHistory: billingHistories,
                vmi: db.Vmi,
                arcturusType: db.ArcturusType,
                restApiAccess: false,
                ssoAccess: false);

            return enrichedDb;
        });

        // 1.1 Figure out which Databases belong to which endusers
        Dictionary<int, List<int>> euDbMapping = new();

        allEndUserDatabases.ForEach(euDb =>
        {
            if (euDbMapping.ContainsKey(euDb.EndUserId))
            {
                euDbMapping[euDb.EndUserId].Add(euDb.DbId);
            }
            else
            {
                euDbMapping.Add(euDb.EndUserId, new List<int> { euDb.DbId });
            }
        });

        List<EndUser> enrichedEndUsers = new List<EndUser>();

        foreach (var euDBList in euDbMapping)
        {
            var thisEndUser = allEndUsers
                .Where(allEu => allEu.Id == euDBList.Key);
            var orgId = thisEndUser.Select(eu => eu.OrganizationID).FirstOrDefault() ?? 0;

            var endUser = new EndUser()
            {
                ID = euDBList.Key,
                Name = thisEndUser.Select(eu => eu.Name).FirstOrDefault(),
                OrganizationID = orgId,
                SSOOrganizationID = allPureOrganizations.FirstOrDefault(po => po.OrganizationID == orgId)?.SSOOrganizationID
            };
            
            endUser.Databases = processedDatabases
                .Where(pd => euDBList.Value.Contains(pd.DbId));
            
            enrichedEndUsers.Add(endUser);
        }


        // Attached EndUsers to Distributors
        Dictionary<int, List<int>> distEuMapping = new();

        allDistributorEndUsers.ForEach(distEu =>
        {
            if (distEuMapping.ContainsKey(distEu.DistributorId))
            {
                distEuMapping[distEu.DistributorId].Add(distEu.EndUserId);
            }
            else
            {
                distEuMapping.Add(distEu.DistributorId, new List<int> { distEu.EndUserId });
            }
        });

        var enrichedDistributors = new List<Distributor>();

        foreach (var distEuList in distEuMapping)
        {
            var thisDistributor = allDistributors
                .Where(allDist => allDist.Id == distEuList.Key);
            
            var orgId = thisDistributor.Select(eu => eu.OrganizationID).FirstOrDefault() ?? 0;
            
            enrichedDistributors.Add(new Distributor()
            {
                ID = distEuList.Key,
                Name = thisDistributor.Select(distDist => distDist.Name).FirstOrDefault(),
                OrganizationID = thisDistributor.Select(dist => dist.OrganizationID).FirstOrDefault() ?? 0,
                SSOOrganizationID = allPureOrganizations.FirstOrDefault(po => po.OrganizationID == orgId)?.SSOOrganizationID,
                Direct = thisDistributor.Select(dist => dist.Direct).FirstOrDefault(),
                EndUsers = enrichedEndUsers.Where(e => distEuList.Value.Contains(e.ID))
            });
        }

        // 3. Attach EndUsers to Distributors
        var ids = allDistributorEndUsers.Select(deu => deu.EndUserId).ToList();
        IEnumerable<Organization> flattened = enrichedEndUsers
            .Where(enriched => !ids.Contains(enriched.ID));


        var total = flattened.Concat(enrichedDistributors);
        // 4. Return list of Distributors and Direct EndUsers
        return total;
    }

    #endregion
}