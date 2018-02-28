using MongoDB.Bson.Serialization.Conventions;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;
using YourProductApi.Infrastructure.Properties;

namespace YourProductApi.Infrastructure.Data
{
    public class MongoContext : IMongoContext
    {
        public IMongoDatabase Database { get; set; }

        public MongoContext()
        {
            var client = new MongoClient(Resources.MongoDbConnectionString);
            this.Database = client.GetDatabase(Resources.MongoDbDatabase);

            var conventionPack = new ConventionPack { new CamelCaseElementNameConvention() };
            ConventionRegistry.Register("camelCase", conventionPack, t => true);
        }
    }
}
