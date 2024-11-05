using Billing.Application.Interfaces;
using Billing.Domain.Entities.Dto;
using MediatR;

namespace Billing.Application.UseCases.Organizations;

public record GetAllDistributorsQuery(bool rebuildCache = false) : IRequest<IEnumerable<DistributorDto>>;

public interface IGetDistributorsQueryHandler
{
    Task<IEnumerable<DistributorDto>> Handle(GetAllDistributorsQuery request, CancellationToken cancellationToken);
}

public class GetDistributorsQueryHandler(
    IOrganizationCacheServices organizationCacheServices) : IRequestHandler<GetAllDistributorsQuery, IEnumerable<DistributorDto>>, IGetDistributorsQueryHandler
{
    public async Task<IEnumerable<DistributorDto>> Handle(GetAllDistributorsQuery request, CancellationToken cancellationToken)
    {
       return await organizationCacheServices.GetAllDistributorsAsync(request.rebuildCache, cancellationToken); 
    }
}