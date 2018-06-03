using Microsoft.AspNetCore.Mvc;
using DirectInjection.Services;

namespace DirectInjection.Controllers {

    public class Request {
        public string Name { set; get; }
    }

    [Route("api/[controller]/[action]")]
    public class GreetingController : Controller {

        [HttpPost]
        public ActionResult<string> Hello([FromBody] Request request, IHelloService service) =>
            $"{service.SayHello()} {request.Name}";

        [HttpPost]
        public ActionResult<string> Byte([FromBody] Request request, IGoodbyeService service) =>
            $"{service.SayGoodBye()} {request.Name}";
    }
}
