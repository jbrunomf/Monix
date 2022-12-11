using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Monix.Models;

[Table("People")]
public abstract class Person
{
    public Guid Id { get; set; }
    [DataType(DataType.EmailAddress)]
    [StringLength(120, ErrorMessage = "O campo {0} deve conter até {1} caracteres.")]
    public string? Email { get; set; }

    [NotMapped]
    public List<Phone> Phones { get; set; }
}