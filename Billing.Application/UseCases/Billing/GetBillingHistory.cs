using Billing.Application.Interfaces;
using Billing.Domain.Entities.Dto;
using MediatR;

namespace Billing.Application.UseCases.Billing;


public record GetAllBillingHistoryQuery(bool rebuildCache = false) : IRequest<IEnumerable<BillingDto>>;

public interface IGetBillingHistoryQueryHandler
{
    Task<IEnumerable<BillingDto>> Handle(GetAllBillingHistoryQuery request, CancellationToken cancellationToken);
}

public class GetBillingHistoryQueryHandler(
    IOrganizationCacheServices organizationCacheServices) : IRequestHandler<GetAllBillingHistoryQuery, IEnumerable<BillingDto>>, IGetBillingHistoryQueryHandler
{
    public async Task<IEnumerable<BillingDto>> Handle(GetAllBillingHistoryQuery request, CancellationToken cancellationToken)
    {
       return await organizationCacheServices.GetAllBillingHistoryAsync(request.rebuildCache, cancellationToken);
    }
}