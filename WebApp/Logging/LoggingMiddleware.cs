using Common.Logging;
using Microsoft.Owin;
using System;
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
            var request = context.Request;
            var response = context.Response;

            var time = Stopwatch.StartNew();
            try
            {
                await Next.Invoke(context);
                time.Stop();

                Log.Info(log =>
                    log("{0} {1} -> {2} {3} [{4}ms]",
                        request.Method, request.Uri,
                        response.StatusCode, response.ReasonPhrase,
                        time.ElapsedMilliseconds));
            }
            catch (Exception exception)
            {
                time.Stop();
                Log.Error(log =>
                    {
                        var content = "TODO";
                        log("Error processing request\r\n" +
                            "{0} {1}\r\n" +
                            "{2}\r\n" +
                            "{3}",
                            request.Method, request.Uri,
                            request.Headers,
                            content ?? "[empty]");
                    },
                    exception);
            }
        }
    }
}