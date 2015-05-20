using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Web.Http;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class RegistrationController : ApiController
    {
        public IEnumerable<Registration> Get()
        {
            return new Collection<Registration> {
                new Registration { Name = "Bill", Email = "bill@example.com", Password = "password" },
                new Registration { Name = "John", Email = "john@example.com", Password = "password" },
                new Registration { Name = "Joe", Email = "joe@example.com", Password = "password" }
            };
        }

        public Registration Get(int id)
        {
            return new Registration { Name = "Bill", Email = "bill@example.com", Password = "password" };
        }

        public IHttpActionResult Post(Registration registration)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Created(Url.Href(new { id = 123 }), registration);
        }
    }
}
