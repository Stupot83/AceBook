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
        private static IMongoCollection<BsonDocument> ConnectToDB(string AceBookDB, string collectionName)
        {
            var connectionString = "mongodb://localhost:27017";

            var client = new MongoClient(MongoUrl.Create(connectionString));

            var database = client.GetDatabase(AceBookDB);

            return database.GetCollection<BsonDocument>(collectionName);
        }

        public static void RegisterUser(string firstName, string lastName, string email, string password, string phoneNumber, string birthDate, string gender)
        {
            var collection = ConnectToDB("AceBookDb", "user");
            var document = new BsonDocument
            {
                { "firstName", firstName },
                { "lastName", lastName },
                { "email", email },
                { "password", PasswordHasher.Hash(password) },
                { "phoneNumber", phoneNumber },
                { "birthDate", birthDate },
                { "gender", gender }
            };

            collection.InsertOneAsync(document);
        }
    }
}
