using System.ComponentModel.DataAnnotations;

namespace Monix.Core.Requests.Categories
{
    public class CreateCategoryRequest : Request
    {
        [Required(ErrorMessage = "Título inválido.")]
        [MaxLength(80, ErrorMessage = "{0} Deve conter até {1} caracteres.")]
        public string Title { get; set; } = string.Empty;

        [Required(ErrorMessage = "Descrição inválida.")]
        public string Description { get; set; } = string.Empty;
    }
}
