using Billing.Domain.Entities.Dto;
using Microsoft.EntityFrameworkCore;

namespace Billing.Infrastructure.Persistence;



internal class EndUserDatabaseRepository(
    IDbContextFactory<AppDbContext> _factory) :  IEndUserDatabaseRepository
{
    public async Task<List<EndUserDatabaseDto>> GetAllAsync()
    {
        using (var ctx = _factory.CreateDbContext())
        {
            return await ctx.EndUserDatabase.AsQueryable().ToListAsync();
        }
    }

    public async Task<EndUserDatabaseDto> GetSpecificEndUserDatabaseAsync(EndUserDatabaseDto endUserDatabaseDto)
    {
        
        using (var ctx = _factory.CreateDbContext())
        {
            return await ctx.EndUserDatabase.FirstOrDefaultAsync(x =>
                        x.Id == endUserDatabaseDto.Id);
        }
        
    }
}