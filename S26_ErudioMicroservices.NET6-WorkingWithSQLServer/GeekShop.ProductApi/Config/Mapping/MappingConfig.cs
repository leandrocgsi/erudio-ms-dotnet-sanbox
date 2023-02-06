using AutoMapper;
using GeekShop.ProductApi.DTOs;
using GeekShop.ProductApi.Model;

namespace GeekShop.ProductApi.Config.Mapping
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration(config =>
            {
                config.CreateMap<ProductDto, Product>();
                config.CreateMap<Product, ProductDto>();
            });
            return mappingConfig;
           
        }
    }
}
