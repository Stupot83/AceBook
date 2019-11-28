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

        public static void RegisterUser(string firstName, string lastName, string email, string password, string phoneNumber, string birthDate, string gender)
        {
            var collection = ConnectToDB("AceBookDB", "user");
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

        public static bool GetUser(string enteredEmail, string enteredPassword)
        {
            var collection = ConnectToDB("AceBookDB", "user");
            try
            {
                var user = collection.Find(new BsonDocument("email", enteredEmail)).First();
                if (PasswordHasher.Verify(enteredPassword, (string)user.GetValue("password")))
                {
                    return true;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
            return false;
        }

        public static void SetPost(string userId, string message, string datePosted)
        {
            var collection = ConnectToDB("AceBookDB", "post");
            var document = new BsonDocument
            {
                { "userId", userId },
                { "message", message },
                { "datePosted", datePosted }
            };

            collection.InsertOneAsync(document);
        }

        public static BsonDocument GetPost(string postId)
        {
            var collection = ConnectToDB("AceBookDB", "post");
            var post = collection.Find(new BsonDocument("_id", postId)).First();

            return post;
        }
    }
}
