namespace Monix.Core.Requests
{
    public class CreateCategoryRequest : Request
    {
        public string Title { get; set; } = String.Empty;
        public string Description { get; set; } = String.Empty;
    }
}
