using System.ComponentModel.DataAnnotations;


namespace Monix.Core.Requests.Categories;

public class GetCategoryByIdRequest
{
    [Required(ErrorMessage = "O Id da categoria precisa ser informado")]
    public long Id { get; set; }
}