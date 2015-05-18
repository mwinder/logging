using Common.Logging;
using Common.Logging.Configuration;
using Common.Logging.Log4Net;
using Newtonsoft.Json.Serialization;
using System.Web.Http;
using WebApp.Logging;

namespace WebApp
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration configuration)
        {
            LogManager.Adapter = new Log4NetLoggerFactoryAdapter(new NameValueCollection {
                { "configType", "INLINE" }
            });

            configuration.MessageHandlers.Add(new ApiUsage());

            configuration.Formatters
                .JsonFormatter.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();

            configuration.MapHttpAttributeRoutes();
            configuration.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
