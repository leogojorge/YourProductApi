using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;
using YourProductApi.Domain;
using YourProductApi.Infrastructure.Data;

namespace YourProductApi.InfrastructureTests.IntegrationTests.Data
{
    public class MongoContextTests
    {
        [Fact]
        public void ShouldCreateDatabase()
        {
            MongoContext sut = new MongoContext();
            sut.Database.CreateCollection("Aviator");

            var collection = sut.Database.ListCollections();

            collection.MoveNext();

            var createdCollection = collection.Current.Any(x => x.ContainsValue("Aviator"));
            Assert.True(createdCollection);
        }
    }
}
