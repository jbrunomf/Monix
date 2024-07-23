using Microsoft.AspNetCore.Mvc;

namespace Monix.Api.Controllers
{
    [ApiController]
    public class HomeController : ControllerBase
    {
        public IActionResult Index()
        {
            return Ok();
        }
    }
}
