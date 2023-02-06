using GeekShop.MessageBus;

namespace GeekShop.PaymentApi.Messages
{
    public class PaymentMessage : BaseMessage
    {
        public int OrderId { get; set; }
        public string Name { get; set; }
        public string CardNumber { get; set; }
        public string CVV { get; set; }
        public string ExpiryMonthYear { get; set; }
        public decimal PurchaseAmount { get; set; }
        public string Email { get; set; }
    }
}
