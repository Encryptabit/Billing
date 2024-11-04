using Billing.Domain.Entities.Dto;

namespace Billing.Infrastructure.Persistence;

public interface IEndUsersRepository
{
    Task<List<EndUserDto>> GetAllAsync();
    Task<EndUserDto> GetSpecificEndUserAsync(EndUserDto endUserDto);
}