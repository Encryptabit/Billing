using Billing.Application.Interfaces;
using MediatR;
using WorkOS;

namespace Billing.Application.UseCases.Organizations;

public record GetWorkOSConnectionsQuery(bool rebuildCache) : IRequest<WorkOSList<Connection>>;

public interface IGetWorkOSConnectionsQueryHandler
{
    Task<WorkOSList<Connection>> Handle(GetWorkOSConnectionsQuery request, CancellationToken cancellationToken);
}

public class GetWorkOSConnectionsQueryHandler(
    IOrganizationCacheServices cacheServices): IRequestHandler<GetWorkOSConnectionsQuery, WorkOSList<Connection>>, IGetWorkOSConnectionsQueryHandler
{
    public async Task<WorkOSList<Connection>> Handle(GetWorkOSConnectionsQuery request, CancellationToken cancellationToken)
    {
        return await cacheServices.GetWorkOSConnectionsAsync(request.rebuildCache, cancellationToken);
    }
}