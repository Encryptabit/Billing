﻿using Billing.Application.Interfaces;
using Microsoft.Extensions.Configuration;
using WorkOS;

namespace Billing.Infrastructure.ExternalServices;

public class WorkOSService : IWorkOSService
{
    private readonly SSOService _ssoService; 
    
    public WorkOSService(string apiKey, SSOService ssoService)
    {
        WorkOS.WorkOS.SetApiKey(apiKey);
        _ssoService = ssoService;
    }

    public async Task<WorkOSList<Connection>> FetchWorkOSConnectionsAsync()
    {
        return await _ssoService.ListConnections();
    }
}