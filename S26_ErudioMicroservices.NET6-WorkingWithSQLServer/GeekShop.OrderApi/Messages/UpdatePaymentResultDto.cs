namespace GeekShop.OrderApi.Messages
{
    public class UpdatePaymentResultDto
    {
        public int OrderId { get; set; }
        public bool Status { get; set; }
        public string Email { get; set; }
    }
}
