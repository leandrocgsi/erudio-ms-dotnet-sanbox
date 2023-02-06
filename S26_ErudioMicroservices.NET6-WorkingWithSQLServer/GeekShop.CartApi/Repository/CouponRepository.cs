using GeekShop.CartApi.DTOs;
using GeekShop.CartApi.IRepository;
using System.Net.Http.Headers;
using System.Net;
using System.Text.Json;

namespace GeekShop.CartApi.Repository
{
    public class CouponRepository : ICouponRepository
    {
        private readonly HttpClient _client;
        public const string BasePath = "api/v1/coupon";

        public CouponRepository(HttpClient client)
        {
            _client = client;
        }

        public async Task<CouponDto> GetCoupon(string couponCode, string token)
        {
            //"api/v1/coupon"
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var response = await _client.GetAsync($"/api/v1/coupon/{couponCode}");
            var content = await response.Content.ReadAsStringAsync();
            
            if (response.StatusCode != HttpStatusCode.OK) return new CouponDto();
            return JsonSerializer.Deserialize<CouponDto>(content,
                new JsonSerializerOptions
                { PropertyNameCaseInsensitive = true });
        }
    }
}
