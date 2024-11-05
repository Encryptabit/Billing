using Billing.Application.Interfaces;
using Billing.Domain.Entities.Dto;
using MediatR;

namespace Billing.Application.UseCases.Organizations;

public record GetAllDistributorEndUsersQuery(bool rebuildCache = false) : IRequest<IEnumerable<DistributorEndUserDto>>;

public interface IGetDistributorEndUsersQueryHandler
{
    Task<IEnumerable<DistributorEndUserDto>> Handle(GetAllDistributorEndUsersQuery request, CancellationToken cancellationToken);
}

public class GetDistributorEndUsersQueryHandler(
    IOrganizationCacheServices  organizationCacheServices) : IRequestHandler<GetAllDistributorEndUsersQuery, IEnumerable<DistributorEndUserDto>>, IGetDistributorEndUsersQueryHandler
{
    public async Task<IEnumerable<DistributorEndUserDto>> Handle(GetAllDistributorEndUsersQuery request, CancellationToken cancellationToken)
    {
       return await organizationCacheServices.GetAllDistributorEndUsersAsync(request.rebuildCache, cancellationToken); 
    }
}