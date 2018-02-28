using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using YourProductApi.AutoMapperCore;
using YourProductApi.Domain;
using YourProductApi.Domain.IRepositories;
using YourProductApi.Infrastructure.Models;

namespace YourProductApi.Infrastructure
{
    public class ProductRepository : IProductRepository
    {
        private const int resultPerPage = 50;

        private IMongoContext MongoContext;
        private IMapperCore mapper;

        public IMongoCollection<ProductMongo> ProductCollection
        { get { return MongoContext.Database.GetCollection<ProductMongo>("product"); } }

        public ProductRepository(IMongoContext mongoDbSettings, IMapperCore mapper)
        {
            this.MongoContext = mongoDbSettings;
            this.mapper = mapper;
        }

        public IList<Product> GetAll()
        {
            var productAsMongo = ProductCollection.Find(x => true).ToList();

            return mapper.Map<IList<ProductMongo>, IList<Product>>(productAsMongo);
        }

        public Product GetById(string id)
        {
            try
            {
                var filter = Builders<ProductMongo>.Filter.Eq("_id", new BsonObjectId(new ObjectId(id)));

                var productAsMongo = ProductCollection.Find(filter).SingleOrDefault();

                return mapper.Map<ProductMongo, Product>(productAsMongo);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Product GetByCode(string code)
        {
            var productAsMongo = ProductCollection.Find(x => x.code == code).SingleOrDefault();

            return mapper.Map<ProductMongo, Product>(productAsMongo);
        }

        public long GetTotalOfPagesToPaging()
        {
            long allProducts = GetQuantityOfProducs();
            long productsPerPage = 50;

            return allProducts / productsPerPage;
        }

        public long GetQuantityOfProducs()
        {
            try
            {
                return ProductCollection.Count(x => true);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Save(Product product)
        {
            var productAsMongo = mapper.Map<Product, ProductMongo>(product);

            try
            {
                ProductCollection.InsertOne(productAsMongo);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            product.Id = productAsMongo.id;
        }

        public void Update(string id, Product product)
        {
            var productAsMongo = mapper.Map<Product, ProductMongo>(product);

            try
            {
                ProductCollection.ReplaceOne(x => x.id.Equals(new BsonObjectId(new ObjectId(id))),
                productAsMongo,
                new UpdateOptions { IsUpsert = true });
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Delete(string id)
        {
            var filter = Builders<ProductMongo>.Filter.Eq("_id", new BsonObjectId(new ObjectId(id)));

            try
            {
                ProductCollection.DeleteOne(filter);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IList<Product> GetWithPaging(int pageNum)
        {
            try
            {
                var productAsMongo = ProductCollection.Find(x => true).
                    Skip(resultPerPage * pageNum).
                    Limit(resultPerPage).
                    SortByDescending(x => x.id).
                    ToList();

                return mapper.Map<IList<ProductMongo>, IList<Product>>(productAsMongo);
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public IList<Product> GetWithPagingWithFieldFilter(int pageNum, string fields)
        {
            string setFieldsTrue = $"{{ {fields.Replace(",", ": 1, ")} }}";

            string fieldsSettedToTrue = setFieldsTrue.Replace("}", ": 1 }");

            try
            {
                var productAsMongo = ProductCollection.Find(x => true).
                Skip(resultPerPage * pageNum).
                Limit(resultPerPage).
                SortByDescending(x => x.id).
                Project<ProductMongo>(fieldsSettedToTrue).
                ToList();

                return mapper.Map<IList<ProductMongo>, IList<Product>>(productAsMongo);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}