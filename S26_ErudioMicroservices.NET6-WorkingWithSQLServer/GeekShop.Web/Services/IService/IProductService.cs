using GeekShop.Web.Models;

namespace GeekShop.Web.Services.IService
{
    public interface IProductService
    {
        Task<IEnumerable<ProductViewModel>> GetProducts(string token);
        Task<ProductViewModel> GetProductById(int id, string token);
        Task<ProductViewModel> AddProduct(ProductViewModel input, string token);
        Task<ProductViewModel> UpdateProduct(ProductViewModel input, string token);
        Task<bool> DeleteProduct(int id, string token);
    }
}
