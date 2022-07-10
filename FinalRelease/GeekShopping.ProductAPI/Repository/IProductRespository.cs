using GeekShopping.ProductAPI.Data.DTOs;

namespace GeekShopping.ProductAPI.Repository
{
    public interface IProductRespository
    {
        Task<IEnumerable<ProductDTO>> FindAll();
        Task<ProductDTO> FindById(long id);
        Task<ProductDTO> Create(ProductDTO productDTO);
        Task<ProductDTO> Update(ProductDTO productDTO);
        Task<bool> Delete(long id);
    }
}
