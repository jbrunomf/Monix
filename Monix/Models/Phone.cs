using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Monix.Models;

[Table("Phones")]
public class Phone
{
    public Guid Id { get; set; }
    public Guid PersonId { get; set; }
    [ForeignKey("PersonId")]
    public virtual Person Person { get; set; }
    [Display(Name = "Número")]
    [StringLength(11, MinimumLength = 10, ErrorMessage = "O campo {0} deve conter {1} dígitos.")]
    [DataType(DataType.PhoneNumber)]
    public string Number { get; set; }

    [Display(Name = "Tipo")]
    public EPhoneType Type { get; set; }
}

public enum EPhoneType
{
    [Display(Name = "Particular")] Personal , [Display(Name = "Comercial")] Business, [Display(Name = "Residencial")] Residential, [Display(Name = "Outros")] Other 
}