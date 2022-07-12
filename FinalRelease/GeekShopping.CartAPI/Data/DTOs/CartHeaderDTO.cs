namespace GeekShopping.CartAPI.Data.DTOs
{
    public class CartHeaderDTO
    {
        public long Id { get; set; }
        public string UserId { get; set; }
        public string? CouponCode { get; set; }
    }
}
