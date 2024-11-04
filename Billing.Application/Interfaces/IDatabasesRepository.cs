using Billing.Domain.Entities.Dto;

namespace Billing.Application.Interfaces;
public interface IDatabasesRepository
{
    Task<List<DatabaseDto>> GetAllAsync();
    Task<DatabaseDto> GetSpecificDatabase(DatabaseDto databaseDto);
}

