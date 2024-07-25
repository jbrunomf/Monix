using Microsoft.AspNetCore.Mvc;

namespace Monix.Api.Controllers
{
    [ApiController]
    public class CategoryController : ControllerBase
    {
        [HttpGet("api/v1/categories")]
        public IActionResult Index()
        {
            return Ok();
        }
    }
}
