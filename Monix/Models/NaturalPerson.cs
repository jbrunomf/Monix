using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Monix.Models;

public enum EGender
{
    [Display(Name = "Masculino")] Male, [Display(Name = "Feminino")] Female, [Display(Name = "Outros")] Other
}

[Table("NaturalPerson")]
public class NaturalPerson : Person
{
    [Display(Name = "Nome")]
    [Required]
    [StringLength(120, ErrorMessage = "O campo {0} deve conter até {1} caracteres.")]
    public string FirstName { get; set; }
    [Display(Name = "Sobrenome")]
    [Required]
    [StringLength(120, ErrorMessage = "O campo {0} deve conter até {1} caracteres.")]
    public string LastName { get; set; }

    [Display(Name = "CPF")]
    [StringLength(11, MinimumLength = 11, ErrorMessage = "O campo {0} deve conter {1} caracteres." )]
    public string CPF { get; set; }

    [Required]
    [Display(Name = "Sexo")]
    public EGender Gender { get; set; }
    
}