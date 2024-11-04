using Billing.Application.Interfaces;
using Billing.Domain.Entities.Dto;
using Microsoft.EntityFrameworkCore;

namespace Billing.Infrastructure.Persistence;

internal class DatabasesRepository(
    IDbContextFactory<AppDbContext> _factory) : IDatabasesRepository
{
    public async Task<List<DatabaseDto>> GetAllAsync()
    {
        using (var ctx = _factory.CreateDbContext())
        {
            return await ctx.Databases.AsQueryable().ToListAsync();
        }
    }

    public async Task<DatabaseDto> GetSpecificDatabase(DatabaseDto databaseDto)
    {
        using (var ctx = _factory.CreateDbContext())
        {
            return await ctx.Databases.FirstOrDefaultAsync(x =>
                        x.DbId == databaseDto.DbId);
        }
    }
}