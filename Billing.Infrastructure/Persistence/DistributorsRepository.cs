using Billing.Domain.Entities;
using Billing.Domain.Entities.Dto;
using Microsoft.EntityFrameworkCore;

namespace Billing.Infrastructure.Persistence;

internal class DistributorsRepository(
    IDbContextFactory<AppDbContext> _factory) : IDistributorsRepository
{
    public async Task<List<DistributorDto>> GetAllAsync()
    {
        using (var ctx = _factory.CreateDbContext())
        {
            return await ctx.Distributors.AsQueryable().ToListAsync();
        }
    }

    public async Task<DistributorDto> GetSpecificDistributorAsync()
    {
        return new DistributorDto();
    }
}