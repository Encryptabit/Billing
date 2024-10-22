using WorkOS;

namespace Billing.Application.Interfaces;

public interface ICacheService
{
    Task<List<int>> GetRestApiParticipantsAsync();
    Task<WorkOSList<Connection>> GetWorkOSConnectionsAsync();
}