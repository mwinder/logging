using Common.Logging;
using Common.Logging.Configuration;
using Common.Logging.Log4Net;
using Microsoft.Owin;
using Owin;
using System.Web.Http;
using WebApp.Logging;

[assembly: OwinStartup(typeof(WebApp.Startup))]

namespace WebApp
{
    public class Startup
    {
        public void Configuration(IAppBuilder application)
        {
            LogManager.Adapter = new Log4NetLoggerFactoryAdapter(new NameValueCollection {
                { "configType", "INLINE" }
            });

            application.Use<LoggingMiddleware>();

            var configuration = new HttpConfiguration();
            application.UseWebApp(configuration);
        }
    }
}
