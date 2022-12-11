using System.ComponentModel.DataAnnotations;

namespace Monix.ViewModels;

public class UserLoginViewModel
{
    [Display(Name = "Usuário")]
    [Required(ErrorMessage = "O campo {0} é de preenchimento obrigatório.")]
    public string Username { get; set; }
    
    [DataType(DataType.Password)]
    [Required(ErrorMessage = "O campo {0} é de preenchimento obrigatório.")]
    public string Password { get; set; }
    
    [Required]
    [Display(Name = "Lembrar de mim")]
    public bool RememberUsername { get; set; }
    
}