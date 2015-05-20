using System;
using System.Web.Http;

namespace WebApp.Controllers
{
    public class ErrorController : ApiController
    {
        public IHttpActionResult Get()
        {
            throw new Exception("Example error");
        }
    }
}
