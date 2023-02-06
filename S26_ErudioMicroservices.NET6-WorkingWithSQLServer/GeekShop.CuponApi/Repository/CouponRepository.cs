using AutoMapper;
using GeekShop.CouponApi.DTOs;
using GeekShop.CouponApi.IRepository;
using GeekShop.CuponApi.Model.DataContext;
using Microsoft.EntityFrameworkCore;

namespace GeekShop.CouponApi.Repository
{
    public class CouponRepository : ICouponRepository
    {
        private readonly DataContext _dataContext;
        private readonly IMapper  _mapper;

        public CouponRepository(DataContext dataContext, IMapper mapper)
        {
            _dataContext = dataContext;
            _mapper = mapper;
        }

        public async Task<CouponDTO> GetCouponByCouponCode(string couponCode)
        {
            var coupon = await _dataContext.Coupons.FirstOrDefaultAsync(c => c.CouponCode == couponCode);
            return _mapper.Map<CouponDTO>(coupon);
        }
    }
}