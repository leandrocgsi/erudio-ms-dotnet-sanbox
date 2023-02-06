namespace GeekShop.CartApi.DTOs
{
    public class CartHeaderDto
    {
        public string UserId { get; set; } = string.Empty;
        public string CouponCode { get; set; } = string.Empty ;

        public decimal DiscountAmount { get; set; }
    }
}
