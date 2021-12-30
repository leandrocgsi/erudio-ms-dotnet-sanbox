namespace GeekShopping.Web.Data.ValueObjects
{
    public class ProductModel
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public string Description { get; set; }
        public string CategoryName { get; set; }
        public string ImageURL { get; set; }
    }
}
