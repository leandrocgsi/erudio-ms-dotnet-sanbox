
using GeekShop.Web.Models;

namespace GeekShop.Web.Services.IService
{
    public interface ICouponService
    {
        Task<CouponViewModel> GetCoupon(string code, string token);
     }
}
