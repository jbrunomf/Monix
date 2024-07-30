using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Monix.Api.Data;
using Monix.Core.Models;
using Monix.Core.Requests.Categories;
using Monix.Core.Responses;

namespace Monix.Api.Controllers
{
    [ApiController]
    public class CategoryController : ControllerBase
    {
        [HttpPost("api/v1/categories")]
        public async Task<IActionResult> Create(AppDbContext context, CreateCategoryRequest request)
        {

            if (!ModelState.IsValid)
                return BadRequest(new Response<object>(ModelState.Values));

            var category = new Category()
            {
                Description = request.Description,
                UserId = request.UserId,
                Title = request.Title
            };

            var added = await context.Categories.AddAsync(category);
            await context.SaveChangesAsync();

            return Created($"/v1/categories/{added.Entity.Id}", added.Entity.Id);
        }

        [HttpGet("api/v1/categories")]
        public IActionResult GetAll(AppDbContext context)
        {
            var categoriesList = context.Categories.ToList();
            return Ok(new Response<List<Category>>(categoriesList));
        }
    }
}
