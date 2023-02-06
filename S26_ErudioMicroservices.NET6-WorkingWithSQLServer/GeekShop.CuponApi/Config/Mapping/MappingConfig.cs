using AutoMapper;
using GeekShop.CouponApi.DTOs;
using GeekShop.CuponApi.Model;

namespace GeekShop.CouponApi.Config.Mapping
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration(config =>
            {
                config.CreateMap<CouponDTO, Coupon>().ReverseMap();
            });
            return mappingConfig;
        }
    }
}
