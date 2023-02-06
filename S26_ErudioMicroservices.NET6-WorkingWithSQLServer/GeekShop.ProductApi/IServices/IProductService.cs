using GeekShop.ProductApi.DTOs;

namespace GeekShop.ProductApi.IServices
{
    public interface IProductService
    {
        Task<IEnumerable<ProductDto>> GetProducts();
        Task<ProductDto> GetProductById(int id);
        Task<ProductDto> AddProduct(ProductDto product);
        Task<ProductDto> UpdateProduct(ProductDto product);
        Task<bool> DeleteProduct(int id);
    }
}
