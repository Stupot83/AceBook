using System;
using System.Configuration;
using System.Collections.Generic;
using System.IO;
using AceBook.Models;
using System.Drawing;
using System.Web;
using MongoDB.Bson;
using MongoDB.Driver;

namespace AceBook.Helpers
{
    public class DbHelper
    {
        private static IMongoCollection<BsonDocument> ConnectToDB(string dbName, string collectionName)
        {
            var connectionString = "mongodb://localhost:27017";

            var client = new MongoClient(MongoUrl.Create(connectionString));

            var database = client.GetDatabase(dbName);

            return database.GetCollection<BsonDocument>(collectionName);
        }
    }
}
