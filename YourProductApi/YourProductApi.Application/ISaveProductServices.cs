using YourProductApi.Application.Models.Request;
using YourProductApi.Application.Models.Response;

namespace YourProductApi.Application
{
    public interface ISaveProductServices
    {
        SavedProductResponse SaveProduct(SaveProductRequest product);
        UpdateProductResponse UpdateProduct(string id, UpdateProductRequest product);
        DeleteProductResponse DeleteProduct(string id);
    }
}
