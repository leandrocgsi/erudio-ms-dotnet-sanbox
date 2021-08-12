using GeekShopping.Web.Data.ValueObjects;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GeekShopping.Web.Services.IServices
{
    public interface IProductService
    {
        Task<IEnumerable<ProductVO>> FindAllProducts();
        Task<ProductVO> FindProductById(long id);
        Task<ProductVO> CreateProduct(ProductVO vo);
        Task<ProductVO> UpdateProduct(ProductVO vo);
        Task<bool> DeleteProductById(long id);
    }
}
