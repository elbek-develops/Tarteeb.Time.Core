using Microsoft.AspNetCore.Mvc;
using RESTFulSense.Controllers;

namespace Tarteeb.Time.Core.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HomeController : RESTFulController
    {
        [HttpGet]
        public ActionResult<string> Get() => Ok("Time microservice is up and running!");
    }
}
