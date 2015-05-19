using Common.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http.ExceptionHandling;

namespace WebApp.Logging
{
    public class ErrorLog : ExceptionLogger
    {
        private static readonly ILog Logger = LogManager.GetLogger<ErrorLog>();

        public override void Log(ExceptionLoggerContext context)
        {
            var request = context.Request;
            Logger.Error(
                log => log("Error processing request\r\n" +
                           "{0} {1}\r\n" +
                           "{2}",
                           request.Method, request.RequestUri,
                           request.Headers),
                context.Exception);
        }
    }
}