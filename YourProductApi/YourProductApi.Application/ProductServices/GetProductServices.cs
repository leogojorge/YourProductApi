using System;
using System.Collections.Generic;
using YourProductApi.Application.Models.Response;
using YourProductApi.AutoMapperCore;
using YourProductApi.Domain;
using YourProductApi.Domain.IRepositories;

namespace YourProductApi.Application.ProductServices
{
    public class GetProductServices : IGetProductServices
    {
        private readonly IProductRepository productRepository;
        private readonly IMapperCore mapper;

        public GetProductServices(IProductRepository productRepository, IMapperCore mapper)
        {
            this.productRepository = productRepository;
            this.mapper = mapper;
        }

        public GetProductResponse GetProductsById(string id)
        {
            GetProductResponse productResponse;

            try
            {
                var product = productRepository.GetById(id);

                productResponse = mapper.Map<Product, GetProductResponse>(product);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return productResponse;
        }

        public GetProductsByPagingResponse GetProductsByPaging(int pageNumber, string fields)
        {
            long totalOfPages = productRepository.GetTotalOfPagesToPaging();

            if (pageNumber > totalOfPages)
                return new GetProductsByPagingResponse { Error = "Page number is out of range" , ActualPage = pageNumber,TotalPages =totalOfPages};

            IList<Product> products;

            try
            {
                if(string.IsNullOrEmpty(fields))
                    products = productRepository.GetWithPaging(pageNumber);
                else
                    products = productRepository.GetWithPagingWithFieldFilter(pageNumber,fields);

                return new GetProductsByPagingResponse
                {
                    ActualPage = pageNumber,
                    ProductResponse = mapper.Map<IList<Product>, IList<GetProductResponse>>(products),
                    TotalPages = totalOfPages,
                };
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}
