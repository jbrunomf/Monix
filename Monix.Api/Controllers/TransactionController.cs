using Microsoft.AspNetCore.Mvc;

namespace Monix.Api.Controllers
{
    public class TransactionController : ControllerBase
    {
        [HttpPost("/api/v1/transactions")]
        public async Task<IActionResult> Index()
        {
            return Ok();
        }
    }
}
