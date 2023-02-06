using GeekShop.CartApi.DTOs;
using GeekShop.CartApi.IRepository;
using GeekShop.CartApi.IService;

namespace GeekShop.CartApi.Services
{
    public class CouponService : ICouponService
    {
        private readonly ICouponRepository _couponRepository;
        public CouponService(ICouponRepository couponRepository)
        {
            _couponRepository = couponRepository;
        }

        public async Task<CouponDto> GetCoupon(string couponCode, string token)
        {
            var couponDto = await _couponRepository.GetCoupon(couponCode, token);
            return couponDto;
        }
    }
}
