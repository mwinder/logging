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

        public IHttpActionResult Post()
        {
            throw new Exception("Example error");
        }

        public IHttpActionResult Put()
        {
            throw new Exception("Example error");
        }

        public IHttpActionResult Delete()
        {
            throw new Exception("Example error");
        }
    }
}
