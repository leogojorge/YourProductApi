using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace YourProductApi.Domain.Sevices.Validator
{
    public class ProductValidator : IValidator
    {
        public IList<string> Erros { get; set; } = new List<string>();
        private Product _product;
        private ValidationAttribute _validationAttribute;

        public ProductValidator(Product product)
        {
            _product = product;
            _validationAttribute = new UrlAttribute();
        }

        public bool IsValid()
        {
            if (string.IsNullOrEmpty(_product.Name))
                Erros.Add("Product must have a name");

            //else if (_product.Name.Any(s => !char.IsLetterOrDigit(s)))
            //    Erros.Add("Product name must have only letters or numbers");

            if (string.IsNullOrEmpty(_product.Description))
                Erros.Add("Product must have a description");

            if (string.IsNullOrEmpty(_product.Code))
                Erros.Add("Product must have a code");

            if (string.IsNullOrEmpty(_product.Brand))
                Erros.Add("Product must have a brand");

            if (string.IsNullOrEmpty(_product.ImageUrl))
                Erros.Add("Product must have a image URL");

            else if (!_validationAttribute.IsValid(_product.ImageUrl))
                Erros.Add("Product must have valid image URL");

            if (string.IsNullOrEmpty(_product.Type))
                Erros.Add("Product must have a type");

            if (_product.Price == 0)
                Erros.Add("Product must have price higher than 0");

            return Erros.Count == 0;
        }
    }
}
