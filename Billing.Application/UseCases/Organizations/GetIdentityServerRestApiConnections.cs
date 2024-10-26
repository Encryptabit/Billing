using Billing.Application.Interfaces;
using MediatR;

namespace Billing.Application.UseCases.Organizations;

/**
 * A new command is created where it will be used at, passed to the handler retrieved from DI 
 */
public record GetIdentityServerRestApiConnectionsQuery(bool refreshCache) : IRequest<List<int>>;

/**
 * Interface needed for DI 
 */
public interface IGetIdentityServerRestApiConnectionsQueryHandler
{
    Task<List<int>> Handle(GetIdentityServerRestApiConnectionsQuery request, CancellationToken cancellationToken);
}

/**
 * Handle the request to get Rest API Participants. This is called from the Presentation Layer,
 * and relies on the implementation in the Infrastructure Layer.
 */
public class GetIdentityServerRestApiConnectionsQueryHandler(
    IOrganizationCacheServices cacheServices) : IRequestHandler<GetIdentityServerRestApiConnectionsQuery, List<int>>, IGetIdentityServerRestApiConnectionsQueryHandler
{
    public async Task<List<int>> Handle(GetIdentityServerRestApiConnectionsQuery request, CancellationToken cancellationToken)
    {
       return await cacheServices.GetRestApiConnectionsAsync(request.refreshCache, cancellationToken); 
    }
}