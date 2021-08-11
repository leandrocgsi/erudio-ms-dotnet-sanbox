using GeekShopping.Web.Data.ValueObjects;
using System.Threading.Tasks;

namespace GeekShopping.Web.Services.IServices
{
    public interface IProductService
    {
        Task<T> FindAllProductsAsync<T>();
        Task<T> FindProductByIdAsync<T>(long id);
        Task<T> CreateProductAsync<T>(ProductVO vo);
        Task<T> UpdateProductAsync<T>(ProductVO vo);
        Task<T> DeleteProductByIdAsync<T>(long id);
    }
}
