namespace GeekShopping.ShoppingCartAPI.Data.ValueObjects
{
    public class CartDetailVO
    {
        public long Id { get; set; }
        public int CartHeaderId { get; set; }
        public virtual CartHeaderVO CartHeader { get; set; }
        public int ProductId { get; set; }
        public virtual ProductVO Product { get; set; }
        public int Count { get; set; }
    }
}