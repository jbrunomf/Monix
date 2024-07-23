using Microsoft.AspNetCore.Mvc;

namespace Monix.Api.Controllers
{
    [ApiController]
    public class CategoryController : ControllerBase
    {
        public IActionResult Index()
        {
            return Ok();
        }
    }
}
