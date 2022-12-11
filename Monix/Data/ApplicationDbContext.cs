using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Monix.Models;

namespace Monix.Data;

[Table("LegalPerson")]
public class ApplicationDbContext : IdentityDbContext<IdentityUser>
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public DbSet<Person> People { get; set; }
    public DbSet<NaturalPerson> NaturalPersons { get; set; }
    public DbSet<LegalPerson> LegalPersons { get; set; }
    public DbSet<Phone> Phones { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<ProductCategory> ProductCategories { get; set; }
}