using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Monix.Core.Models;

namespace Monix.Api.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Category> Categories { get; set; } = null!;
        public DbSet<Transaction> Transactions { get; set; } = null!;


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
