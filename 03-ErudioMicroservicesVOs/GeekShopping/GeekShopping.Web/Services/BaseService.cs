using GeekShopping.Web.Services.IServices;
using GeekShopping.Web.Utils;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace GeekShopping.Web.Services
{
    public class BaseService : IBaseService
    {
        public IHttpClientFactory _httpClient {  get; set; }

        public BaseService(IHttpClientFactory httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<T> SendAsync<T>(ApiRequest request)
        {
            try
            {
                var client = _httpClient.CreateClient("GeekShoppingAPI");
                HttpRequestMessage message = new HttpRequestMessage();
                message.Headers.Add("Accept", "application/json");
                message.RequestUri = new Uri(request.Url);
                client.DefaultRequestHeaders.Clear();
                if (request.Data != null)
                {
                    var dataAsString = JsonSerializer.Serialize(request.Data);
                    message.Content = new StringContent(dataAsString,
                                        Encoding.UTF8, "application/json");
                }

                if (!string.IsNullOrEmpty(request.AccessToken))
                {
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", request.AccessToken);
                }

                HttpResponseMessage apiResponse = null;
                switch (request.ApiType)
                {
                    case HttpClientExtensions.ApiType.POST:
                        message.Method = HttpMethod.Post;
                        break;
                    case HttpClientExtensions.ApiType.PUT:
                        message.Method = HttpMethod.Put;
                        break;
                    case HttpClientExtensions.ApiType.DELETE:
                        message.Method = HttpMethod.Delete;
                        break;
                    default:
                        message.Method = HttpMethod.Get;
                        break;
                }
                apiResponse = await client.SendAsync(message);

                var apiContent = await apiResponse.Content.ReadAsStringAsync();
                var apiResponse = JsonSerializer.Deserialize<T>(apiContent, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
          
                return apiResponse;
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public void Dispose()
        {
            GC.SuppressFinalize(true);
        }


    }
}
