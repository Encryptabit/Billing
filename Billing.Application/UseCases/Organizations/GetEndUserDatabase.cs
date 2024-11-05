using Billing.Application.Interfaces;
using Billing.Domain.Entities;
using Billing.Domain.Entities.Dto;
using MediatR;

namespace Billing.Application.UseCases.Organizations;

public record GetAllEndUserDatabasesQuery(bool rebuildCache = false): IRequest<IEnumerable<EndUserDatabaseDto>>;

public interface IGetEndUserDatabasesQueryHandler
{
    Task<IEnumerable<EndUserDatabaseDto>> Handle(GetAllEndUserDatabasesQuery request,
        CancellationToken cancellationToken);
}

public class GetEndUserDatabasesQueryHandler(
    IOrganizationCacheServices organizationCacheServices) : IRequestHandler<GetAllEndUserDatabasesQuery, IEnumerable<EndUserDatabaseDto>>, IGetEndUserDatabasesQueryHandler
{
    public async Task<IEnumerable<EndUserDatabaseDto>> Handle(GetAllEndUserDatabasesQuery request,
        CancellationToken cancellationToken)
    {
        return await organizationCacheServices.GetAllEndUserDatabasesAsync(request.rebuildCache, cancellationToken);
    }
}