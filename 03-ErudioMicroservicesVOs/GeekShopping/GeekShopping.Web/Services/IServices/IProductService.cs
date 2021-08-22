using GeekShopping.Web.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GeekShopping.Web.Services.IServices
{
    public interface IProductService
    {
        Task<IEnumerable<ProductModel>> FindAllProducts();
        Task<ProductModel> FindProductById(long id);
        Task<ProductModel> CreateProduct(ProductModel vo);
        Task<ProductModel> UpdateProduct(ProductModel vo);
        Task<bool> DeleteProductById(long id);
    }
}
