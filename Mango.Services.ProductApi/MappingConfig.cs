using AutoMapper;
using Mango.Services.ProductApi.Models;
using Mango.Services.ProductApi.Models.Dto;

namespace Mango.Services.ProductApi;

public class MappingConfig
{
    public static MapperConfiguration RegisterMap()
    {
        var mappingConfig = new MapperConfiguration(Config =>
        {
            Config.CreateMap<ProductDto, Product>();
            Config.CreateMap<Product, ProductDto>();
        });
        return mappingConfig;
    }      
  }
