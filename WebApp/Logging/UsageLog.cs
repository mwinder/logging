using Common.Logging;
using System.Diagnostics;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace WebApp.Logging
{
    public class UsageLog : DelegatingHandler
    {
        private static readonly ILog Log = LogManager.GetLogger<UsageLog>();

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            var time = Stopwatch.StartNew();
            var response = await base.SendAsync(request, cancellationToken);
            time.Stop();

            Log.Info(log =>
                log("{0} {1} -> {2} {3} [{4}ms]",
                    request.Method, request.RequestUri,
                    (int)response.StatusCode, response.ReasonPhrase,
                    time.ElapsedMilliseconds));

            return response;
        }
    }
}