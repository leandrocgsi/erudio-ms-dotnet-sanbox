using AutoMapper;
using GS.Product.API.Data.ValueObjects;

namespace GS.Product.API.Config
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration(config =>
            {
                config.CreateMap<ProductVO, Product.API.Model.Product>();
                config.CreateMap<Product.API.Model.Product, ProductVO>();
            });

            return mappingConfig;
        }
    }
}
