using GeekShop.Web.Models;
using GeekShop.Web.Services.IService;
using GeekShop.Web.Utils;
using System.Net.Http.Headers;

namespace GeekShop.Web.Services
{
    public class ProductService : IProductService
    {
        private readonly HttpClient _client;
        public const string BasePath = "api/v1/Product";
        
        public ProductService(HttpClient client)
        {
            _client = client ?? throw new ArgumentException(nameof(ProductService));            
        }

        public async Task<IEnumerable<ProductViewModel>> GetProducts(string token)
        {
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var response = await _client.GetAsync(BasePath);
            return await response.ReadContentAs<List<ProductViewModel>>();
        }
        public async Task<ProductViewModel> GetProductById(int id, string token)
        {
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var response = await _client.GetAsync($"{BasePath}/{id}");
            return await response.ReadContentAs<ProductViewModel>();            
        }

        public async Task<ProductViewModel> AddProduct(ProductViewModel input, string token)
        {
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var response = await _client.PostAsJson(BasePath, input);

            if (response.IsSuccessStatusCode)
                return await response.ReadContentAs<ProductViewModel>(); 
            else
                throw new Exception("Something went wrong when calling API");
        }

        public async Task<ProductViewModel> UpdateProduct(ProductViewModel input, string token)
        {
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var response = await _client.PutAsJson(BasePath, input);

            if (response.IsSuccessStatusCode)
                return await response.ReadContentAs<ProductViewModel>();
            else
                throw new Exception("Something went wrong when calling API");
        }

        public async Task<bool> DeleteProduct(int id, string token)
        {
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var response = await _client.DeleteAsync($"{BasePath}/{id}");

            if (response.IsSuccessStatusCode)
                return await response.ReadContentAs<bool>();
            else
                throw new Exception("Something went wrong when calling API");
        }
    }
}
