using MongoDB.Bson;
using System;
using Xunit;
using YourProductApi.Infrastructure.Models;

namespace YourProductApi.InfrastructureTests.IntegrationTests.Models
{
    public class ProductMongoTests
    {
        ProductMongo sut;

        public ProductMongoTests()
        {
            sut = CreateProductMongo();
        }

        public ProductMongo CreateProductMongo()
        {
            return new ProductMongo
            {
                brand = "Chevrolet",
                code = "ut51Gjqi351",
                description = "Cabeçote chev opala 77",
                id = ObjectId.GenerateNewId().ToString(),
                imageUrl = "https://www.google.com.br/search?q=cabeçote+opala.jpg",
                name = "Cabeçote",
                price = 700,
                type = "Autopeças"
            };
        }

        [Fact]
        public void ShouldSerializeProductIdAttribute()
        {
            var document = sut.ToBsonDocument();

            Assert.Equal(BsonType.ObjectId, document["_id"].BsonType);
        }

        [Fact]
        public void ShouldSerializeProductPriceAttribute()
        {
            var document = sut.ToBsonDocument();

            Assert.Equal(BsonType.Double, document["price"].BsonType);
        }
    }
}
