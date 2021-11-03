using AutoMapper;
using GeekShopping.ShoppingCartAPI.Data.ValueObjects;
using GeekShopping.ShoppingCartAPI.Model;

namespace GeekShopping.CartAPI.Config
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration(config => {
                config.CreateMap<ProductVO, Product>().ReverseMap();
                config.CreateMap<CartHeader, CartHeaderVO>().ReverseMap();
                config.CreateMap<CartDetail, CartDetailVO>().ReverseMap();
                config.CreateMap<Cart, CartVO>().ReverseMap();
            });
            return mappingConfig;
        }
    }
}
