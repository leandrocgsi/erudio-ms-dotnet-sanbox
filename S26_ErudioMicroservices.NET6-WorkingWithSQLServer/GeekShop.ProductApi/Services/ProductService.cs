using GeekShop.ProductApi.DTOs;
using GeekShop.ProductApi.IRepository;
using GeekShop.ProductApi.IServices;

namespace GeekShop.ProductApi.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<IEnumerable<ProductDto>> GetProducts()
        {
            var productsDto = await _productRepository.GetProducts();
            return productsDto;
        }

        public async Task<ProductDto> GetProductById(int id)
        {
            var productDto = await _productRepository.GetProductById(id);
            return productDto;
        }

        public async Task<ProductDto> AddProduct(ProductDto inputProductDto)
        {
            var productDto = await _productRepository.AddProduct(inputProductDto);
            return productDto;
        }

        public async Task<ProductDto> UpdateProduct(ProductDto inputProductDto)
        {
            var productDto = await _productRepository.UpdateProduct(inputProductDto);
            return productDto;
        }

        public async Task<bool> DeleteProduct(int id)
        {
            var productDto = await _productRepository.DeleteProduct(id);
            return productDto;
        }        
    }
}
