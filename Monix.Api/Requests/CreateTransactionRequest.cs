using Monix.Core.Enums;

namespace Monix.Api.Requests
{
    public class CreateTransactionRequest
    {
        public string Title { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public ETransactionType Type{ get; set; }
        public decimal Amount { get; set; }
        public long CategoryId { get; set; }
        public string UserId { get; set; } = string.Empty;
    }
}
