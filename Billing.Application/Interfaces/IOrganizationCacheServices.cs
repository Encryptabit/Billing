using Billing.Domain.Entities;
using Billing.Domain.Entities.Dto;
using WorkOS;
using Organization = Billing.Domain.Entities.Organization;

namespace Billing.Application.Interfaces;

public interface IOrganizationCacheServices
{
    // External APIs
    Task<WorkOSList<Connection>> GetWorkOSConnectionsAsync(bool rebuildCache, CancellationToken cancellationToken);
    Task<List<int>> GetRestApiConnectionsAsync(bool rebuildCache, CancellationToken cancellationToken);

    // BillingHistory
    Task<List<BillingDto>> GetAllBillingHistoryAsync(bool rebuildCache = false,
        CancellationToken cancellationToken = default);
    Task<List<BillingDto>> GetSpecificOrganizationsBillingHistoryAsync(OrganizationDto organization, CancellationToken cancellationToken);
    
    // Database
    Task<List<DatabaseDto>> GetAllDatabasesAsync(bool rebuildCache = false,
        CancellationToken cancellationToken = default);
    Task<DatabaseDto> GetSpecificDatabaseAsync(OrganizationDto organization, CancellationToken cancellationToken);
    
    // DistributorEndUser
    Task<List<DistributorEndUserDto>> GetAllDistributorEndUsersAsync(bool rebuildCache = false,
        CancellationToken cancellationToken = default);
    Task<DistributorEndUserDto> GetSpecificDistributorEndUserAsync(OrganizationDto organization, CancellationToken cancellationToken);

    // Distributors
    Task<List<DistributorDto>> GetAllDistributorsAsync(bool rebuildCache = false, CancellationToken cancellationToken = default);
    Task<DistributorDto> GetSpecificDistributorAsync(DistributorDto distributor);

    // EndUserDatabase
    Task<List<EndUserDatabaseDto>> GetAllEndUserDatabasesAsync(bool rebuildCache = false,
        CancellationToken cancellationToken = default);
    Task<EndUserDatabaseDto> GetSpecificEndUserDatabaseAsync(OrganizationDto organization, CancellationToken cancellationToken);
    // EndUsers
    Task<List<EndUserDto>> GetAllEndUsersAsync(bool rebuildCache = false, CancellationToken cancellationToken = default);
    Task<EndUserDto> GetSpecificEndUserAsync(EndUserDto endUser);
    
    // Organizations
    Task<List<OrganizationDto>> GetAllOrganizationsAsync(bool rebuildCache = false,
        CancellationToken cancellationToken = default);
    Task<OrganizationDto> GetSpecificOrganizationAsync(OrganizationDto organization, CancellationToken cancellationToken);

    Task<IEnumerable<Organization>> GetConstructedOrganizationsAsync(bool rebuildCache = false);
}