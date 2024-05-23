
using Microsoft.Extensions.DependencyInjection;

using System.Net;
using System.Net.Http.Headers;
using TakGhahCore.Options.ModelSession;

namespace TakGhahWeb.Services.Implements;

public partial class AppHttpClientHandler : HttpClientHandler
{
    protected HttpClient HttpClient { get; set; } = new()!;

    protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
    {
        var access_token = UserSeession.Token!;
        HttpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", access_token);

        if (request.Headers.Authorization is null)
        {

            if (access_token is not null)
            {
                request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", access_token);
            }
        }



        var response = await base.SendAsync(request, cancellationToken);

        if (response.StatusCode is HttpStatusCode.Unauthorized)
        {
            throw new();
        }



        response.EnsureSuccessStatusCode();

        return response;
    }
}
