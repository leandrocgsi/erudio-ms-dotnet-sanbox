using AutoMapper;
using GeekShopping.ProductAPI.Data.DTOs;
using GeekShopping.ProductAPI.Model;

namespace GeekShopping.ProductAPI.Config
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration(config =>
            {
                config.CreateMap<ProductDTO, Product>();
                config.CreateMap<Product, ProductDTO>();
            });

            return mappingConfig;
        }
    }
}
