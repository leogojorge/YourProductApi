using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace YourProductApi.Infrastructure.Models
{
    public class ProductMongo
    {
        [BsonRepresentation(BsonType.ObjectId)]
        public string id { get; set; }
        [BsonIgnoreIfNull]
        public string name { get; set; }
        [BsonIgnoreIfNull]
        public string description { get; set; }
        [BsonIgnoreIfNull]
        public string imageUrl { get; set; }
        [BsonIgnoreIfNull]
        public string type { get; set; }
        [BsonIgnoreIfNull]
        [BsonRepresentation(BsonType.Double)]
        public decimal price { get; set; }
        [BsonIgnoreIfNull]
        public string brand { get; set; }
        [BsonIgnoreIfNull]
        public string code { get; set; }
    }
}
