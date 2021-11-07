using GeekShopping.Web.Models;
using GeekShopping.Web.Services.IServices;
using GeekShopping.Web.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Reflection;
using System.Threading.Tasks;

namespace GeekShopping.Web.Services
{
    public class CouponService : ICouponService
    {
        private readonly HttpClient _client;
        public const string BasePath = "api/v1/coupon";

        public CouponService(HttpClient client)
        {
            _client = client ?? throw new ArgumentNullException(nameof(client));
        }

        public async Task<CouponViewModel> GetCoupon(string couponCode, string token)
        {
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var response = await _client.GetAsync($"{BasePath}/{couponCode}");
            if (response.StatusCode != HttpStatusCode.OK) return new CouponViewModel();
            return await response.ReadContentAs<CouponViewModel>();
        }
    }
}