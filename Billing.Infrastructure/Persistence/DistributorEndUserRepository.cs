using Billing.Domain.Entities.Dto;
using Microsoft.EntityFrameworkCore;

namespace Billing.Infrastructure.Persistence;

internal class DistributorEndUserRepository(
    IDbContextFactory<AppDbContext> _factory) : IDistributorEndUserRepository
{
    public async Task<List<DistributorEndUserDto>> GetAllAsync()
    {
        using (var ctx = _factory.CreateDbContext())
        {
            return await ctx.DistributorEndUsers.AsQueryable().ToListAsync();
        }
    }

    public async Task<DistributorEndUserDto> GetSpecificDistributorEndUserAsync(
        DistributorEndUserDto distributorEndUserDto)
    {
        using (var ctx = _factory.CreateDbContext())
        {
            return await ctx.DistributorEndUsers.FirstOrDefaultAsync(x =>
                x.Id == distributorEndUserDto.Id);
        }
    }
}