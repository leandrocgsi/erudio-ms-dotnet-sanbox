using GeekShop.CouponApi.DTOs;

namespace GeekShop.CouponApi.IRepository
{
    public interface ICouponRepository
    {
        Task<CouponDTO> GetCouponByCouponCode(string couponCode);
    }
}
