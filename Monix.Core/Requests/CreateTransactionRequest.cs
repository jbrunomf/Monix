using Monix.Core.Enums;

namespace Monix.Core.Requests
{
    public class CreateTransactionRequest : Request
    {
        public string Title { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public ETransactionType Type{ get; set; }
        public decimal Amount { get; set; }
        public long CategoryId { get; set; }
    }
}
