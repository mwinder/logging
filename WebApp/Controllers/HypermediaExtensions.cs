using System.Web.Http.Routing;

namespace WebApp.Controllers
{
    public static class HypermediaExtensions
    {
        public static string Href(this UrlHelper url, object routeValues)
        {
            return url.Link("DefaultApi", routeValues);
        }
    }
}