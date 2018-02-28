
using System.Collections.Generic;
using YourProductApi.Application.Models.Response;

namespace YourProductApi.Application
{
    public interface IGetProductServices
    {
        GetProductsByPagingResponse GetProductsByPaging(int pageNumber, string fields);
        GetProductResponse GetProductsById(string id);
    }
}