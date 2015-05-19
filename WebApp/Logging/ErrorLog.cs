using Common.Logging;
using System.Web.Http.ExceptionHandling;
using WebApp.Helpers;

namespace WebApp.Logging
{
    public class ErrorLog : ExceptionLogger
    {
        private static readonly ILog Logger = LogManager.GetLogger<ErrorLog>();

        public override void Log(ExceptionLoggerContext context)
        {
            var request = context.Request;

            Logger.Error(
                async log =>
                {
                    var content = await request.GetContent();
                    log("Error processing request\r\n" +
                        "{0} {1}\r\n" +
                        "{2}\r\n" +
                        "{3}",
                        request.Method, request.RequestUri,
                        request.Headers,
                        content);
                },
                context.Exception);
        }
    }
}