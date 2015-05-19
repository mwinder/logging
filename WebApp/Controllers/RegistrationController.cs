using System.Web.Http;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class RegistrationController : ApiController
    {
        public Registration Get(int id)
        {
            return new Registration
            {
                Name = "Bill Johnson",
                Email = "bill@example.com",
                Password = "password"
            };
        }

        public IHttpActionResult Post(Registration registration)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Created(Url.Link("DefaultApi", new { id = 123 }), registration);
        }
    }
}
