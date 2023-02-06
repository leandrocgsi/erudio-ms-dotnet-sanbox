
using GeekShop.CartApi.DTOs;

namespace GeekShop.CartApi.IService
{
    public interface ICouponService
    {
        Task<CouponDto> GetCoupon(string couponCode, string token);
    }
}
