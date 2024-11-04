using Billing.Domain.Entities.Dto;

namespace Billing.Application.Interfaces;

public interface IBillingRepository
{
    Task<List<BillingDto>> GetAllAsync();
    Task<BillingDto> GetSpecificEndUserAsync(BillingDto billingDto);
}