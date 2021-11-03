using GeekShopping.ShoppingCartAPI.Model.Base;

namespace GeekShopping.ShoppingCartAPI.Data.ValueObjects
{
    public class CartHeaderVO
    {
        public long Id { get; set; }
        public string UserId { get; set; }
        public string CouponCode { get; set; }
    }
}
