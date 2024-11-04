using Billing.Domain.Entities.Dto;
using Microsoft.EntityFrameworkCore;

namespace Billing.Infrastructure.Persistence;

internal class EndUsersRepository(
    IDbContextFactory<AppDbContext> _factory) : IEndUsersRepository
{
    
    public async Task<List<EndUserDto>> GetAllAsync()
    {
        using (var ctx = _factory.CreateDbContext())
        {
            return await ctx.EndUsers.AsQueryable().ToListAsync();
        }
    }

    public async Task<EndUserDto> GetSpecificEndUserAsync(EndUserDto endUserDto)
    {
        
        using (var ctx = _factory.CreateDbContext())
        {
            return await ctx.EndUsers.FirstOrDefaultAsync(x =>
                        x.Id == endUserDto.Id);
        }
        
    }
}