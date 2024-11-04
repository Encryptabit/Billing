using Billing.Domain.Entities.Dto;

namespace Billing.Infrastructure.Persistence;

public interface IEndUserDatabaseRepository
{
    Task<List<EndUserDatabaseDto>> GetAllAsync();
    Task<EndUserDatabaseDto> GetSpecificEndUserDatabaseAsync(EndUserDatabaseDto endUserDatabaseDto);
}