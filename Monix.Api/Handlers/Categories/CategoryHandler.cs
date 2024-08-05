using System.Diagnostics;
using Microsoft.EntityFrameworkCore;
using Monix.Api.Data;
using Monix.Core.Handlers;
using Monix.Core.Models;
using Monix.Core.Requests.Categories;
using Monix.Core.Responses;

namespace Monix.Api.Handlers.Categories
{
    public class CategoryHandler(AppDbContext context) : ICategoryHandler
    {
        public async Task<Response<Category?>> CreateAsync(CreateCategoryRequest request)
        {
            try
            {
                var category = new Category()
                {
                    UserId = request.UserId,
                    Title = request.Title,
                    Description = request.Description
                };

                await context.Categories.AddAsync(category);
                await context.SaveChangesAsync();

                return new Response<Category>(category, 201, "Categoria criada com sucesso!");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public async Task<Response<Category?>> UpdateAsync(UpdateCategoryRequest request)
        {
            try
            {
                var category = await context
                    .Categories
                    .AsNoTracking()
                    .FirstOrDefaultAsync(x => x.Id == request.Id && x.UserId == request.UserId);

                if (category is null)
                    return new Response<Category?>(null, 500, "Não foi possível atualizar a categoria.");

                category.Title = request.Title;
                category.Description = request.Description;

                context.Categories.Update(category);
                await context.SaveChangesAsync();

                return new Response<Category?>(category);
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public async Task<Response<Category?>> DeleteAsync(DeleteCategoryRequest request)
        {
            try
            {
                var category = await context
                    .Categories
                    .AsNoTracking()
                    .FirstOrDefaultAsync(x => x.Id == request.Id && x.UserId == request.UserId);

                if (category is null)
                    return new Response<Category?>(null, 500, "Não foi possível remover a categoria.");


                context.Categories.Remove(category);
                await context.SaveChangesAsync();

                return new Response<Category?>(category);
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public async Task<Response<Category?>?> GetByIdAsync(GetCategoryByIdRequest request)
        {
            var category = await context.Categories.FirstOrDefaultAsync(x => x.Id == request.Id && x.UserId == request.UserId);
            return category != null ? new Response<Category?>(category, 200, "") : null;
        }

        public Task<Response<List<Category>>> GetAllAsync(GetAllCategoriesRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
