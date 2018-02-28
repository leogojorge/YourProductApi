using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;

namespace YourProductApi.Infrastructure
{
    public interface IMongoContext
    {
        IMongoDatabase Database { get; set; }
    }
}
