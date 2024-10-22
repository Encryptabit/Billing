namespace Billing.Application.Interfaces;

public interface IIdentityServerService
{
    Task<List<int>> FetchRestApiParticipantsAsync(); 
}