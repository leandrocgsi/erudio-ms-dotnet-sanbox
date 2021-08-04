using LittleItaly.ProductAPI.Data.ValueObjects;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LittleItaly.ProductAPI.Repository
{
    public  interface IProductRepository
    {
        Task<IEnumerable<ProductVO>> GetProducts();
        Task<ProductVO> GetProductById(long productId);
        Task<ProductVO> CreateOrUpdateProduct(ProductVO productVO);
        Task<bool> DeleteProduct(long productId);
    }
}
