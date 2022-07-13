using GeekShopping.CouponAPI.Data.DTOs;

namespace GeekShopping.CouponAPI.Repository
{
    public interface ICouponRepository
    {
        Task<CouponDTO> GetCouponByCouponCode(string couponCode);

    }
}
