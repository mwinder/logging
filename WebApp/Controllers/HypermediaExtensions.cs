using System;
using System.Web.Http.Routing;

namespace WebApp.Controllers
{
    public static class HypermediaExtensions
    {
        public static Uri Href(this UrlHelper url, object routeValues)
        {
            return new Uri(url.Link("DefaultApi", routeValues));
        }
    }
}