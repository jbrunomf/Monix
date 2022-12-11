using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore.Scaffolding.Internal;

namespace Monix.ViewModels;

public class UserRegisterViewModel
{
    public string Id { get; set; }
    
    [Display(Name = "Nome de Usuário")]
    [Required(ErrorMessage = "O campo {0} é de preenchimento obrigatório.")]
    public string UserName { get; set; }

    [DataType(DataType.PhoneNumber)]
    [Required(ErrorMessage = "O campo {0} é de preenchimento obrigatório.")]
    [StringLength(11, ErrorMessage = "O campo {0} deve ter {1} digitos.")]
    public string PhoneNumber { get; set; }

    [Display(Name = "Email")]
    [DataType(DataType.EmailAddress)]
    [Required(ErrorMessage = "O campo {0} é de prenchimento obrigatório.")]
    public string Email { get; set; }
    
    [DataType(DataType.Password)]
    [MaxLength(16, ErrorMessage = "O tamanho máximo do campo {0} [e de {1} caracteres.")]
    [MinLength(6, ErrorMessage = "O tamanho mínimo do campo {0} é de {1} caracteres.")]
    [Required(ErrorMessage = "o campo {0} é de preenchimento obrigatório.")]
    public string Password { get; set; }
    
    [Display(Name = "Confirmação de Senha")]
    [DataType(DataType.Password)]
    [Required(ErrorMessage = "O campo {0} é de preenchimento obrigatório.")]
    [MaxLength(16, ErrorMessage = "O tamanho máximo do campo {0} é de {1} caracteres.")]
    [MinLength(6, ErrorMessage = "O tamanho mínimo do campo {0} é de {1} caracteres.")]
    [Compare(nameof(Password), ErrorMessage = "A confirmação da senha não confere com a senha.")]
    public string PasswordConfirm { get; set; }
}