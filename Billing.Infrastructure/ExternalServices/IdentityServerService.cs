using System.Net.Http.Json;
using Billing.Application.Interfaces;
using IdentityModel.Client;
using Microsoft.Extensions.Configuration;

namespace Billing.Infrastructure.ExternalServices;

public class IdentityServerService: IIdentityServerService
{

  private readonly IConfiguration _configuration;
  private readonly HttpClient _identityClient;
  private readonly IHttpClientFactory _httpClientFactory;

  public IdentityServerService(IHttpClientFactory httpClientFactory, IConfiguration configuration)
  {
    _configuration = configuration;
    _httpClientFactory = httpClientFactory;
    _identityClient = new HttpClient();
  }

  public async Task<List<int>> FetchRestApiConnectionsAsync()
  {
     DiscoveryDocumentResponse discoveryDoc = await _identityClient.GetDiscoveryDocumentAsync();
     
     var tokenResponse = await _identityClient.RequestClientCredentialsTokenAsync(new ClientCredentialsTokenRequest
     {
         Address = discoveryDoc.TokenEndpoint,
         ClientId = _configuration["IdentityServer:ClientId"],
         ClientSecret = _configuration["IdentityServer:ClientSecret"],
         Scope = "arcturuswebapi",
     });
      
     var client = _httpClientFactory.CreateClient();
     
     client.SetBearerToken(tokenResponse.AccessToken);

     string devUrl = _configuration["IdentityServer:DevUrl"],
         stagingUrl = _configuration["IdentityServer:StagingUrl"];
     
     return await client.GetFromJsonAsync<List<int>>(devUrl);
  }
}