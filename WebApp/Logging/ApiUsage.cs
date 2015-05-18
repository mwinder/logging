using Common.Logging;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace WebApp.Logging
{
    public class ApiUsage : DelegatingHandler
    {
        private static readonly ILog Log = LogManager.GetLogger<ApiUsage>();

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            var response = await base.SendAsync(request, cancellationToken);

            Log.Debug(x => x("{0} {1} -> {2} {3}", request.Method, request.RequestUri, (int)response.StatusCode, response.ReasonPhrase));

            return response;
        }
    }
}