using Microsoft.EntityFrameworkCore;

namespace GeekShop.CartApi.Model
{
    public class Cart
    {
        public int Id { get; set; }
        public CartHeader CartHeader { get; set; }
        public IEnumerable<CartDetail> CartDetails { get; set; }
    }
}
