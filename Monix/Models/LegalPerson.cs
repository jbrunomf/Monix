using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Monix.Models;

[Table("LegalPerson")]
public class LegalPerson : Person
{
    [StringLength(14, MinimumLength = 14, ErrorMessage = "O campo {0} deve conter {1} caracteres.")]
    [Required(ErrorMessage = "O campo {0} é de preenchimento obrigatório.")]
    public string CNPJ { get; set; }

    [Display(Name = "Razão Social")]
    [StringLength(120, ErrorMessage = "O campo {0} deve conter até {1} caracteres.")]
    public string CompanyName { get; set; }
    
    [Display(Name = "Mome Fantasia")]
    [StringLength(120, ErrorMessage = "O campo {0} deve conter até {1} caracteres.")]
    public string TradingName { get; set; }
}