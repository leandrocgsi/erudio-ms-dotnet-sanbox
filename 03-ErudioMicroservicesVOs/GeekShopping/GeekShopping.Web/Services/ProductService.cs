using GeekShopping.Web.Data.ValueObjects;
using GeekShopping.Web.Services.IServices;
using GeekShopping.Web.Utils;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace GeekShopping.Web.Services
{
    public class ProductService : IProductService
    {
        private readonly HttpClient _client;
        public const string BasePath = "/api/v1/Product";

        public ProductService(HttpClient client)
        {
            _client = client ?? throw new ArgumentNullException(nameof(client));
        }

        public async Task<IEnumerable<ProductVO>> FindAllProducts()
        {
            var response = await _client.GetAsync(BasePath);
            return await response.ReadContentAs<List<ProductVO>>();
        }

        public async Task<ProductVO> FindProductById(long id)
        {
            var response = await _client.GetAsync($"{BasePath}/{id}");
            return await response.ReadContentAs<ProductVO>();
        }

        public async Task<ProductVO> CreateProduct(ProductVO vo)
        {
            var response = await _client.PostAsJson(BasePath, vo);
            if (response.IsSuccessStatusCode) return await response.ReadContentAs<ProductVO>();
            else throw new Exception("Something went wrong when calling api.");
        }

        public async Task<ProductVO> UpdateProduct(ProductVO vo)
        {
            var response = await _client.PutAsJson(BasePath, vo);
            if (response.IsSuccessStatusCode) return await response.ReadContentAs<ProductVO>();
            else throw new Exception("Something went wrong when calling api.");
        }

        public async Task<bool> DeleteProductById(long id)
        {
            var response = await _client.DeleteAsync($"{BasePath}/{id}");
            if (response.IsSuccessStatusCode) return await response.ReadContentAs<bool>();
            else throw new Exception("Something went wrong when calling api.");
        }
    }
}
