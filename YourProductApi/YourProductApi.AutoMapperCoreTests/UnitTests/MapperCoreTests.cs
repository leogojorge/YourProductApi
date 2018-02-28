using AutoMapper;
using System;
using Xunit;
using YourProductApi.Application.Models.Request;
using YourProductApi.Application.Models.Response;
using YourProductApi.AutoMapperCore;
using YourProductApi.AutoMapperCore.Mappers;
using YourProductApi.Domain;

namespace YourProductApi.AutoMapperCoreTests
{
    public class MapperCoreTests
    {
        public MapperCoreTests()
        {
            Mapper.Initialize(m => m.AddProfile<MappingProfile>());
        }

        [Fact]
        public void ShouldMapSavedProductRequestToProduct()
        {
            SaveProductRequest saveProductRequest = new SaveProductRequest()
            {
                Brand = "Chevrolet",
                Code = "ut51Gjqi351",
                Description = "Cabeçote chev opala 77",
                ImageUrl = "https://www.google.com.br/search?q=cabeçote+opala.jpg",
                Name = "Cabeçote",
                Price = 700,
                Type = "Autopeças"
            };
            MapperCore sut = new MapperCore();

            var product = sut.Map<SaveProductRequest, Product>(saveProductRequest);
            Mapper.Reset();

            Assert.True(product.Brand != null &&
                        product.Code != null &&
                        product.Description != null &&
                        product.ImageUrl != null &&
                        product.Name != null &&
                        product.Price != 0 &&
                        product.Type != null);
        }

        [Fact]
        public void ShouldMapProductToSaveProductResponse()
        {
            Product product = new Product()
            {
                Id = "12345678"
            };
            MapperCore sut = new MapperCore();

            var productSaved = sut.Map<Product, SavedProductResponse>(product);
            Mapper.Reset();

            Assert.Equal(productSaved.Id, product.Id);
        }
    }
}