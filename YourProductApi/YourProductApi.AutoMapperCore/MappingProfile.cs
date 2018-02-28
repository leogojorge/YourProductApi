using AutoMapper;
using YourProductApi.Application.Models.Response;
using YourProductApi.Application.Models.Request;
using YourProductApi.Domain;
using YourProductApi.Infrastructure.Models;

namespace YourProductApi.AutoMapperCore
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Product, ProductMongo>();
            CreateMap<ProductMongo, Product>();
            CreateMap<Product, SavedProductResponse>();
            CreateMap<Product, GetProductResponse>();
            CreateMap<SaveProductRequest, Product>();
            CreateMap<UpdateProductRequest, Product>();
        }
    }
}
