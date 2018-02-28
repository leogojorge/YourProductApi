using AutoMapper;
using System;
using System.Collections.Generic;
using YourProductApi.Application.Models.Request;
using YourProductApi.Application.Models.Response;
using YourProductApi.AutoMapperCore;
using YourProductApi.Domain;
using YourProductApi.Domain.IRepositories;
using YourProductApi.Domain.Sevices;
using YourProductApi.Domain.Sevices.Validator;

namespace YourProductApi.Application.ProductServices
{
    public class SaveProductServices : ISaveProductServices
    {
        private readonly IProductRepository productRepository;
        private readonly IMapperCore mapper;

        public SaveProductServices(IProductRepository productRepository, IMapperCore mapper)
        {
            this.productRepository = productRepository;
            this.mapper = mapper;
        }

        public DeleteProductResponse DeleteProduct(string id)
        {
            if (string.IsNullOrEmpty(id))
                return new DeleteProductResponse { ErrorMessage = "Id is null" };

            if(productRepository.GetById(id) == null)
                return new DeleteProductResponse { ErrorMessage = "Product not found" };

            try
            {
                productRepository.Delete(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return new DeleteProductResponse { Id = id };
        }

        public SavedProductResponse SaveProduct(SaveProductRequest productRequest)
        {
            var product = mapper.Map<SaveProductRequest, Product>(productRequest);

            IValidator productValidator = new ProductValidator(product);

            if (!productValidator.IsValid())
                return new SavedProductResponse { ErrorMessages = productValidator.Erros };

            if (productRepository.GetByCode(product.Code) != null)
            {
                var savedProductResponse = mapper.Map<Product, SavedProductResponse>(product);
                savedProductResponse.ErrorMessages.Add("A product with this code already exists");
                return savedProductResponse;
            }

            try
            {
                productRepository.Save(product);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return mapper.Map<Product, SavedProductResponse>(product);
        }

        public UpdateProductResponse UpdateProduct(string id, UpdateProductRequest productToUpdate)
        {
            var product = mapper.Map<UpdateProductRequest, Product>(productToUpdate);

            IValidator productValidator = new ProductValidator(product);

            if (!productValidator.IsValid())
                return new UpdateProductResponse { ErrorMessages = productValidator.Erros };

            try
            {
                productRepository.Update(id, product);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return new UpdateProductResponse { Id = id };
        }
    }
}
