using AutoMapper;

namespace GeekShop.OrderApi.Config.Mapping
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration(config =>
            {
                //config.CreateMap<ProductDto, Product>().ReverseMap();
                //config.CreateMap<CartHeaderDto, CartHeader>().ReverseMap();
                //config.CreateMap<CartDetailDto, CartDetail>().ReverseMap();
                //config.CreateMap<CartDto, Cart>().ReverseMap();
            });
            return mappingConfig;
        }
    }
}