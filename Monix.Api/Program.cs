using Microsoft.EntityFrameworkCore;
using Monix.Api.Data;
using Monix.Api.Handlers.Categories;
using Monix.Core.Handlers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//ConnectionStrings
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<AppDbContext>(x =>
{
    x.UseSqlServer(connectionString);
});

//Dependency Injection
builder.Services.AddTransient<ICategoryHandler, CategoryHandler>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(x => x.CustomSchemaIds(n => n.FullName));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
