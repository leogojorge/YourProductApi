using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;

namespace YourProductApi.Domain.IRepositories
{
    public interface IProductRepository
    {
        IList<Product> GetAll();
        IList<Product> GetWithPagingWithFieldFilter(int pageNum, string fields);
        IList<Product> GetWithPaging(int pageNum);
        Product GetById(string id);
        Product GetByCode(string code);
        long GetQuantityOfProducs();
        long GetTotalOfPagesToPaging();
        void Update(string id, Product product);
        void Delete(string id);
        void Save(Product product);
    }
}
