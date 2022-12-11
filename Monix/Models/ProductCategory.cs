using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Monix.Models;

[Table("ProductCategory")]
public class ProductCategory
{
    public Guid Id { get; set; }
    [Required]
    [StringLength(120)]
    [Display(Name = "Nome")]
    public string Name { get; set; }
}