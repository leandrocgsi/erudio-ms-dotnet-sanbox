using GeekShop.CartApi.Model;

namespace GeekShop.CartApi.DTOs
{
    public class CartDto
    {
        public int Id { get; set; }
        public CartHeaderDto CartHeader { get; set; }
        public IEnumerable<CartDetailDto> CartDetails { get; set; }
    }
}