using GeekShop.ProductApi.DTOs;

namespace GeekShop.ProductApi.IRepository
{
    public interface IProductRepository
    {
        Task<IEnumerable<ProductDto>> GetProducts();
        Task<ProductDto> GetProductById(int id);
        Task<ProductDto> AddProduct(ProductDto product);
        Task<ProductDto> UpdateProduct(ProductDto product);
        Task<bool> DeleteProduct(int id);
    }
}
