using System;
using System.Web.Http;

namespace WebApp.Controllers
{
    public class ErrorController : ApiController
    {
        public IHttpActionResult Get()
        {
            throw new Exception("GET error");
        }

        public IHttpActionResult Post()
        {
            throw new Exception("POST error");
        }

        public IHttpActionResult Put()
        {
            throw new Exception("PUT error");
        }

        public IHttpActionResult Delete()
        {
            throw new Exception("DELETE error");
        }
    }
}
