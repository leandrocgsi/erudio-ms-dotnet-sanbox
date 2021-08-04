using AutoMapper;
using LittleItaly.ProductAPI.Data.ValueObjects;
using LittleItaly.ProductAPI.Model;

namespace LittleItaly.ProductAPI.Data
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration(config => {
                config.CreateMap<ProductVO, Product>();
                config.CreateMap<Product, ProductVO>();
            });
            return mappingConfig;
        }
    }
}
