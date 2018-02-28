using System;
using System.Linq;
using Xunit;
using YourProductApi.Domain;
using YourProductApi.Domain.Sevices.Validator;

namespace YourProductApi.DomainTests
{
    public class ProductValidatorTests
    {
        [Fact]
        public void ShouldValidateAValidProduct()
        {
            var product = CreateValidProduct();
            var sut = new ProductValidator(product);

            var result = sut.IsValid();

            Assert.True(result);
        }

        [Fact]
        public void ShouldValidateAInvalidProduct()
        {
            var product = CreateInvalidProduct();
            var sut = new ProductValidator(product);

            var result = sut.IsValid();

            Assert.False(result);
        }

        [Fact]
        public void ShouldValidateANullProduct()
        {
            Product product = null;
            var sut = new ProductValidator(product);

            Action result = () => sut.IsValid();

            Assert.Throws<NullReferenceException>(result);
        }

        [Fact]
        public void ShouldValidateAProductWithInvalidImageUrl()
        {
            Product product = CreateValidProduct();
            product.ImageUrl = "www.gg.com.br";
            var sut = new ProductValidator(product);

            var result = sut.IsValid();

            Assert.False(result);
        }

        [Fact]
        public void ShouldGetErroMessageForEmptyName()
        {
            Product product = CreateValidProduct();
            product.Name = "";
            var sut = new ProductValidator(product);

            sut.IsValid();

            var erroMessage = sut.Erros.Where(s => s == "Product must have a name");
            Assert.True(erroMessage.Count() == 1);
        }

        private Product CreateValidProduct()
        {
            return new Product
            {
                Brand = "Chevrolet",
                Code = "ut51Gjqi351",
                Description = "Cabeçote chev opala 77",
                Id = "1",
                ImageUrl = "https://www.google.com.br/search?q=cabeçote+opala.jpg",
                Name = "Cabeçote",
                Price = 700,
                Type = "Autopeças"
            };
        }

        private Product CreateInvalidProduct()
        {
            return new Product();
        }
    }
}
