using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Grpc.Net.Client;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;


namespace GrpcCodeFirst.Server.Test
{
    public class TestServerFixture: WebApplicationFactory<Program>, IDisposable
    {
        #region Public properties
        public GrpcChannel GrpcChannel { get; }
        #endregion
        
        public TestServerFixture()
        {
            // Get require services
            Services.CreateScope();
            
            HttpClient client = CreateDefaultClient(new ResponseVersionHandler());
            if (client.BaseAddress!.ToString().StartsWith("https://") == false)
                client.BaseAddress = new Uri("https://localhost");

            GrpcChannel = GrpcChannel.ForAddress(client.BaseAddress! , new GrpcChannelOptions
            {
                HttpClient = client
            });
        }
        
        
        
        /// <summary>
        /// This handle response before it reaches the client. gRPC requires HTTP/2 and the default version of the response is set to 1.1.
        /// Hence, with the delegating handler, we set the version number of the response back to 2.0 (same as the request)
        /// </summary>
        private class ResponseVersionHandler : DelegatingHandler
        {
            protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request,
                CancellationToken cancellationToken)
            {
                var response = await base.SendAsync(request, cancellationToken);
                response.Version = request.Version;
                return response;
            }
        }
    }
    
    
    
}