using Billing.Application.Interfaces;
using Billing.Domain.Entities;
using Billing.Domain.Entities.Dto;
using Microsoft.EntityFrameworkCore;

namespace Billing.Infrastructure.Persistence;

internal class OrganizationsRepository(
    IDbContextFactory<AppDbContext> _factory) : IOrganizationsRepository
{
    public async Task<List<OrganizationDto>> GetAllAsync()
    {
        using (var ctx = _factory.CreateDbContext())
        {
            return await ctx.Organizations.AsQueryable().ToListAsync();
        }
    }

    public async Task<OrganizationDto> GetSpecificOrganizationAsync(OrganizationDto organization)
    {
        
        using (var ctx = _factory.CreateDbContext())
        {
            return await ctx.Organizations.FirstOrDefaultAsync(x =>
                        x.SSOOrganizationID == organization.SSOOrganizationID);
        }
        
    }
}