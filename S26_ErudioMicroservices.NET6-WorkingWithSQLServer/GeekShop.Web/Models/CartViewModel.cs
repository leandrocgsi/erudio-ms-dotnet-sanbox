namespace GeekShop.Web.Models
{
    public class CartViewModel
    {
        public int Id { get; set; }
        public CartHeaderViewModel CartHeader { get; set; }
        public IEnumerable<CartDetailViewModel> CartDetails { get; set; }
    }
}
