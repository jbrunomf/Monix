using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Validations.Rules;
using Monix.Api.Data;
using Monix.Api.Handlers.Categories;
using Monix.Core.Handlers;
using Monix.Core.Models;
using Monix.Core.Requests.Categories;
using Monix.Core.Responses;

namespace Monix.Api.Controllers
{
    [ApiController]
    public class CategoryController : ControllerBase
    {
        [HttpPost("api/v1/categories")]
        public async Task<IActionResult> Create(AppDbContext context, CreateCategoryRequest request,
            ICategoryHandler handler)
        {

            if (!ModelState.IsValid)
                return BadRequest(new Response<string>("Erro ao adicionar Categoria."));


            var category = await handler.CreateAsync(request);


            return Created($"/v1/categories/{category?.Data?.Id}", category.Data);
        }

        [HttpGet("api/v1/categories")]
        public async Task<IActionResult> GetAll(ICategoryHandler handler)
        {
            var request = new GetAllCategoriesRequest()
            {
                UserId = "string"
            };
            var categoriesList = await handler.GetAllAsync(request);
            return Ok(categoriesList);
        }

        [HttpPut("api/v1/categories/{id}")]
        public async Task<IActionResult> UpdateAsync(long id, UpdateCategoryRequest request,
            ICategoryHandler handler)
        {
            request.Id = id;
            var result = await handler.UpdateAsync(request);
            return Ok(result);
        }

        [HttpDelete("api/v1/categories/{id}")]
        public async Task<IActionResult> DeleteAsync(long id,
            ICategoryHandler handler)
        {
            var request = new DeleteCategoryRequest()
            {
                Id = id
            };
            var result = await handler.DeleteAsync(request);
            return Ok(result);
        }

        [HttpGet("api/v1/categories/{id}")]
        public async Task<IActionResult> GetByIdAsync(GetCategoryByIdRequest request, ICategoryHandler handler)
        {
            var result = await handler.GetByIdAsync(request);
            return Ok(result);
        }
    }
}
