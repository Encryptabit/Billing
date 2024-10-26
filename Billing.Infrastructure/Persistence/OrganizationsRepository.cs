using Billing.Application.Interfaces;
using Billing.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Billing.Infrastructure.Persistence;

public class OrganizationsRepository(
    AppDbContext context) : IOrganizationsRepository
{
    public async Task<List<Organization>> GetAllAsync()
    {
        return await context.Organizations.AsQueryable().ToListAsync();
        
        //return await Task.FromResult(context.Organizations.ToList());
    }

    public async Task<Organization> GetBySsoOrganizationIdAsync(Organization organization)
    {
        return await context.Organizations.FirstOrDefaultAsync(x => x.SSOOrganizationID == organization.SSOOrganizationID);
    }
}