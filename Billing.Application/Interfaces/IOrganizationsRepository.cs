using Billing.Domain.Entities.Dto;

namespace Billing.Application.Interfaces;

public interface IOrganizationsRepository
{
    Task<List<OrganizationDto>> GetAllAsync();
    Task<OrganizationDto> GetSpecificOrganizationAsync(OrganizationDto organization);
}