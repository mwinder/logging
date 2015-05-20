using Common.Logging;
using Microsoft.Owin;
using System.Diagnostics;
using System.Threading.Tasks;

namespace WebApp.Logging
{
    public class LoggingMiddleware : OwinMiddleware
    {
        private static readonly ILog Log = LogManager.GetLogger<LoggingMiddleware>();

        public LoggingMiddleware(OwinMiddleware next)
            : base(next) { }

        public async override Task Invoke(IOwinContext context)
        {
            var time = Stopwatch.StartNew();
            await Next.Invoke(context);
            time.Stop();

            var request = context.Request;
            var response = context.Response;

            Log.Info(log =>
                log("{0} {1} -> {2} {3} [{4}ms]",
                    request.Method, request.Uri,
                    response.StatusCode, response.ReasonPhrase,
                    time.ElapsedMilliseconds));
        }
    }
}