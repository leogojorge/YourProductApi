using MongoDB.Driver;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using YourProductApi.AutoMapperCore;
using YourProductApi.Infrastructure;

namespace YourProductApi.InfrastructureTests.UnitTests.Repository
{
    public class ProductRepositoryTests
    {
        [Fact]
        public void ShouldThrowNullReferenceExceptionWhileExecutingRepositoryMethods()
        {
            var mockMapperCore = new Mock<IMapperCore>();
            var mockMongoContext = new Mock<IMongoContext>();

            var sut = new ProductRepository(mockMongoContext.Object, mockMapperCore.Object);

            Assert.Throws<NullReferenceException>(() => sut.Save(null));
        }
    }
}
