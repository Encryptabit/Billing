using Billing.Application.Interfaces;
using Billing.Domain.Entities.Dto;
using MediatR;

namespace Billing.Application.UseCases.Organizations;

public record GetAllEndUsersQuery(bool rebuildCache) : IRequest<IEnumerable<EndUserDto>>;

public interface IGetEndUsersQueryHandler
{
    Task<IEnumerable<EndUserDto>> Handle(GetAllEndUsersQuery request, CancellationToken cancellationToken);
}

public class GetEndUsersQueryHandler(
    IOrganizationCacheServices organizationCacheServices) : IRequestHandler<GetAllEndUsersQuery, IEnumerable<EndUserDto>>, IGetEndUsersQueryHandler
{
    public async Task<IEnumerable<EndUserDto>> Handle(GetAllEndUsersQuery request, CancellationToken cancellationToken)
    {
        return await organizationCacheServices.GetAllEndUsersAsync(request.rebuildCache, cancellationToken);
    }
}