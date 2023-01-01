using AutoMapper;
using GeekShopping.ProductAPI.Domain.VM;
using GeekShopping.ProductAPI.Implementation.Model.Class;

namespace GeekShopping.ProductAPI.Domain.Config
{
    public class Mapping
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration(config =>
            {
                config.CreateMap<ProductVM, Product>();
                config.CreateMap<Product, ProductVM>();
            });
            return mappingConfig;
        }
    }
}
