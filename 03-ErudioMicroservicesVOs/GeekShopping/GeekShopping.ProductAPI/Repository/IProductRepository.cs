using GeekShopping.ProductAPI.Data.ValueObjects;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GeekShopping.ProductAPI.Repository
{
    public interface IProductRepository
    {
        Task<IEnumerable<ProductVO>> FindAll();
        Task<ProductVO> FindByID(long id);
        Task<ProductVO> Create(ProductVO productVO);
        Task<ProductVO> Update(ProductVO productVO);
        Task<bool> Delete(long id);
    }
}