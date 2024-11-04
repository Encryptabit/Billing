using Billing.Domain.Entities;
using Billing.Domain.Entities.Dto;

namespace Billing.Infrastructure.Persistence;

public interface IDistributorsRepository
{
    Task<List<DistributorDto>> GetAllAsync();
    Task<DistributorDto> GetSpecificDistributorAsync();
}