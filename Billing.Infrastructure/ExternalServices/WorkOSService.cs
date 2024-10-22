using Billing.Application.Interfaces;
using Microsoft.Extensions.Configuration;
using WorkOS;

namespace Billing.Infrastructure.ExternalServices;

public class WorkOSService : IWorkOSService
{
    private readonly SSOService _ssoService; 
    
    public WorkOSService(IConfiguration _configuration, SSOService ssoService)
    {
        WorkOS.WorkOS.SetApiKey(_configuration["WorkOS:ApiKey"]);
        _ssoService = ssoService;
    }

    public async Task<WorkOSList<Connection>> FetchWorkOSConnectionsAsync()
    {
        return await _ssoService.ListConnections();
    }
}