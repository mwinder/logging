using Newtonsoft.Json.Serialization;
using Owin;
using System.Web.Http;
using System.Web.Http.ExceptionHandling;
using WebApp.Logging;

namespace WebApp
{
    public static class WebApiConfig
    {
        public static IAppBuilder UseWebApp(this IAppBuilder app, HttpConfiguration configuration)
        {
            Register(configuration);
            app.UseWebApi(configuration);

            return app;
        }

        private static void Register(HttpConfiguration configuration)
        {
            configuration.MessageHandlers.Add(new UsageLog());

            configuration.Services.Add(typeof(IExceptionLogger), new ErrorLog());

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
