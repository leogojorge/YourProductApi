using AutoMapper;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using YourProductApi.AutoMapperCore;
using YourProductApi.AutoMapperCore.Mappers;
using YourProductApi.Domain;
using YourProductApi.Infrastructure;
using YourProductApi.Infrastructure.Data;

namespace YourProductApi.InfrastructureTests.IntegrationTests.Repository
{
    public class ProductRepositoryTests
    {
        private ProductRepository sut;

        public ProductRepositoryTests()
        {
            Mapper.Initialize(m => m.AddProfile<MappingProfile>());
            sut = new ProductRepository(new MongoContext(), new MapperCore());
        }

        [Fact]
        public void ShouldSaveAProduct()
        {
            Product product = new Product
            {
                Brand = "BBS",
                Code = new ObjectId().ToString(),
                Description = "Aro 18",
                ImageUrl = "https://www.google.com.br/search?q=cabeçote+opala.jpg",
                Name = "Jogo de Rodas",
                Price = 5000,
                Type = "Autopeças"
            };

            sut.Save(product);
            Mapper.Reset();

            Assert.NotNull(product.Id);
        }

        [Fact]
        public void ShouldGetAllProducts()
        {
            var products = sut.GetAll();
            Mapper.Reset();

            Assert.True(products.Count > 1);
        }

        [Fact]
        public void ShouldDeleteAProduct()
        {
            string id = sut.GetAll()[0].Id;

            sut.Delete(id);
            var deletedProduct = sut.GetById(id);
            Mapper.Reset();

            Assert.Null(deletedProduct);
        }

        [Fact]
        public void ShouldUpdateAProduct()
        {
            var product = sut.GetAll()[0];
            product.Brand = "OZ";

            sut.Update(product.Id, product);

            var newProduct = sut.GetById(product.Id);
            Mapper.Reset();

            Assert.Equal(product.Brand, newProduct.Brand);
        }

        [Fact]
        public void ShouldGetEmptyListOfProductsWithAPagingOutOfRange()
        {
            var totalOfPages = sut.GetTotalOfPagesToPaging();
            long numberOutOfRangeOfPages = 1 + totalOfPages;

            var products = sut.GetWithPaging((int)numberOutOfRangeOfPages);
            Mapper.Reset();

            Assert.True(products.Count == 0);
        }

    }
}
