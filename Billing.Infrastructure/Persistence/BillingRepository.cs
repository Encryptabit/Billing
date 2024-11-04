using Billing.Application.Interfaces;
using Billing.Domain.Entities.Dto;
using Microsoft.EntityFrameworkCore;

namespace Billing.Infrastructure.Persistence;

internal class BillingRepository(
    IDbContextFactory<AppDbContext> _factory) : IBillingRepository 
{
    public async Task<List<BillingDto>> GetAllAsync()
    {
        using (var ctx = _factory.CreateDbContext())
        {
            return await ctx.BillingHistory.AsQueryable().ToListAsync();
        }
    }

    public async Task<BillingDto> GetSpecificEndUserAsync(BillingDto billingDto)
    {
        
        using (var ctx = _factory.CreateDbContext())
        {
            return await ctx.BillingHistory.FirstOrDefaultAsync(x =>
                        x.RecordID == billingDto.RecordID);
        }
        
    }
}