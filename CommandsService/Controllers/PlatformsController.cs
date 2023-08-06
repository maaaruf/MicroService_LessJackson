using Microsoft.AspNetCore.Mvc;

namespace CommandsService.Controllers
{
    [Route("api/c/[controller]")]
    [ApiController]
    public class PlatformsController : ControllerBase
    {
       public PlatformsController()
       {
           
       }

        [HttpPost]
        public ActionResult TestInboundConnection()
        {
            Console.WriteLine("--> Inbound POST # Command Service");
            return Ok("Inbound test of from Platforms Controller");
        }

        [HttpGet]
        public ActionResult TestOutboundConnection()
        {
            Console.WriteLine("--> Outbound GET # Command Service");
            return Ok("Outbound test of from Platforms Controller");
        }
    }
}