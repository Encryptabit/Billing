using Billing.Domain.Entities.Dto;

namespace Billing.Infrastructure.Persistence;

public interface IDistributorEndUserRepository
{
    Task<List<DistributorEndUserDto>> GetAllAsync();
    Task<DistributorEndUserDto> GetSpecificDistributorEndUserAsync(DistributorEndUserDto distributorEndUserDto);
}