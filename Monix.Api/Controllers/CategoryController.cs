using Microsoft.AspNetCore.Mvc;
using Monix.Api.Data;
using Monix.Api.Handlers.Categories;
using Monix.Core.Models;
using Monix.Core.Requests.Categories;
using Monix.Core.Responses;

namespace Monix.Api.Controllers
{
    [ApiController]
    public class CategoryController : ControllerBase
    {
        [HttpPost("api/v1/categories")]
        public async Task<IActionResult> Create(AppDbContext context, CreateCategoryRequest request, CategoryHandler handler)
        {

            if (!ModelState.IsValid)
                return BadRequest(new Response<string>("Erro ao adicionar Categoria."));


            var category = await handler.CreateAsync(request);

            return Created($"/v1/categories/{category?.Data?.Id}", category.Data);
        }

        [HttpGet("api/v1/categories")]
        public IActionResult GetAll(AppDbContext context)
        {
            var categoriesList = context.Categories.ToList();
            return Ok(new Response<List<Category>>(categoriesList));
        }
    }
}
