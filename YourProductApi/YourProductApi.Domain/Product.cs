using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;

namespace YourProductApi.Domain
{
    public class Product
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public string Type { get; set; }
        public decimal Price { get; set; }
        public string Brand { get; set; }
        public string Code { get; set; }
    }
}
