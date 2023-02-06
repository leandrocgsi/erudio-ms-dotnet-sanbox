namespace GeekShop.OrderAPI.Messages
{
    public class CartDetailDTO
    {
        public int Id { get; set; }
        public int CartHeaderId { get; set; }
        public int ProductId { get; set; }
        public virtual ProductDTO Product { get; set; }

        public int Count { get; set; }
    }
}
