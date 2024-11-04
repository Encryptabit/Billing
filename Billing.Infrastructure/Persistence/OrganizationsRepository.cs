using Billing.Application.Interfaces;
using Billing.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Billing.Infrastructure.Persistence;

internal class OrganizationsRepository(
    IDbContextFactory<AppDbContext> _factory) : IOrganizationsRepository
{
    public async Task<List<Organization>> GetAllAsync()
    {
        using (var ctx = _factory.CreateDbContext())
        {
            return await ctx.Organizations.AsQueryable().ToListAsync();
        }
    }

    public async Task<Organization> GetSpecificOrganizationAsync(Organization organization)
    {
        
        using (var ctx = _factory.CreateDbContext())
        {
            return await ctx.Organizations.FirstOrDefaultAsync(x =>
                        x.SSOOrganizationID == organization.SSOOrganizationID);
        }
        
    }
}