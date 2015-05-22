using Common.Logging;
using Microsoft.Owin;
using System.Diagnostics;
using System.Threading.Tasks;

namespace WebApp.Logging
{
    public class UsageLoggingMiddleware : OwinMiddleware
    {
        private static readonly ILog Log = LogManager.GetLogger<UsageLoggingMiddleware>();

        public UsageLoggingMiddleware(OwinMiddleware next)
            : base(next) { }

        public async override Task Invoke(IOwinContext context)
        {
            var time = Stopwatch.StartNew();
            await Next.Invoke(context);
            time.Stop();

            var request = context.Request;
            var response = context.Response;

            Log.ThreadVariablesContext.Set("WebApp:requestTime", time.ElapsedMilliseconds + "ms");
            Log.Info(log =>
                log("{0} {1} -> {2} {3}",
                    request.Method, request.Uri,
                    response.StatusCode, response.ReasonPhrase));
            Log.ThreadVariablesContext.Clear();
        }
    }
}