using System.Collections.Generic;

namespace GeekShopping.ShoppingCartAPI.Model
{
    public class Cart
    {
        public CartHeader CartHeader { get; set; }
        public IEnumerable<CartDetail> CartDetails { get; set; }
    }
}
