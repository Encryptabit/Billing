using Billing.Domain.Entities;

namespace Billing.Application.Interfaces;

public interface IOrganizationsRepository
{
    Task<List<Organization>> GetAllAsync();
    Task<Organization> GetSpecificOrganizationAsync(Organization organization);
}