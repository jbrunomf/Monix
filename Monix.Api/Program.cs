using Microsoft.EntityFrameworkCore;
using Monix.Api.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//ConnectionStrings
builder.Configuration.GetConnectionString("Default");
builder.Services.AddDbContext<AppDbContext>(x =>
{
    x.UseSqlServer();
});

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
