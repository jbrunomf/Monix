using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Monix.Models;

[Table("Product")]
public class Product
{
    public Guid Id { get; set; }
    
    [Required]
    [StringLength(120, ErrorMessage = "O campo {0} deve conter até {1} caracteres.")]
    [Display(Name = "Nome")]
    public string Name { get; set; }

    [Display(Name = "Category")]
    public Guid CategoryId { get; set; }
    [ForeignKey("CategoryId")]
    public ProductCategory Category { get; set; }
}