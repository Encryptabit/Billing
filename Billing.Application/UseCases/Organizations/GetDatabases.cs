using Billing.Application.Interfaces;
using Billing.Domain.Entities;
using Billing.Domain.Entities.Dto;
using MediatR;

namespace Billing.Application.UseCases.Organizations;

public record GetAllDatabasesQuery(bool rebuildCache = false) : IRequest<IEnumerable<DatabaseDto>>;

public interface IGetDatabasesQueryHandler
{
    Task<IEnumerable<DatabaseDto>> Handle(GetAllDatabasesQuery request, CancellationToken cancellationToken);
}

public class GetDatabasesQueryHandler(
    IOrganizationCacheServices organizationCacheServices) : IRequestHandler<GetAllDatabasesQuery, IEnumerable<DatabaseDto>>, IGetDatabasesQueryHandler
{
    public async Task<IEnumerable<DatabaseDto>> Handle(GetAllDatabasesQuery request, CancellationToken cancellationToken)
    {
       return await organizationCacheServices.GetAllDatabasesAsync(request.rebuildCache, cancellationToken); 
    }
}