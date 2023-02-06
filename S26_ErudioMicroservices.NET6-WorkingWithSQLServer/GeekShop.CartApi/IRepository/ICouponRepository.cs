using GeekShop.CartApi.DTOs;

namespace GeekShop.CartApi.IRepository
{
    public interface ICouponRepository
    {
        Task<CouponDto> GetCoupon(string couponCode, string token);
    }
}
