using GeekShop.CouponApi.DTOs;
using GeekShop.CouponApi.IRepository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GeekShop.CouponApi.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class CouponController : ControllerBase
    {
        private readonly ICouponRepository _couponRepository;

        public CouponController(ICouponRepository couponRepository)
        {
            _couponRepository = couponRepository ?? throw new ArgumentNullException(nameof(couponRepository));
        }

        [HttpGet("{couponCode}")]
        [Authorize]
        public async Task<ActionResult<CouponDTO>> GetCouponByCouponCode(string couponCode)
        {
            var couponDtoBD = await _couponRepository.GetCouponByCouponCode(couponCode);

            if (couponDtoBD == null) return NotFound();
            return Ok(couponDtoBD);
        }
    }
}
