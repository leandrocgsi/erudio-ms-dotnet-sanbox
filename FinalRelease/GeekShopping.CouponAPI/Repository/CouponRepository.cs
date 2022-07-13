using AutoMapper;
using GeekShopping.CouponAPI.Data.DTOs;
using GeekShopping.CouponAPI.Model.Context;
using Microsoft.EntityFrameworkCore;

namespace GeekShopping.CouponAPI.Repository
{
    public class CouponRepository : ICouponRepository
    {
        private readonly MySqlContext _context;
        private IMapper _mapper;

        public CouponRepository(MySqlContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<CouponDTO> GetCouponByCouponCode(string couponCode)
        {
            var coupon = await _context.Coupons.FirstOrDefaultAsync(c => c.CouponCode == couponCode);
            return _mapper.Map<CouponDTO>(coupon);
        }
    }
}
