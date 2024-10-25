using WorkOS;

namespace Billing.Application.Interfaces;

public interface IWorkOSService
{
    Task<WorkOSList<Connection>> FetchWorkOSConnectionsAsync(CancellationToken cancellationToken); 
}