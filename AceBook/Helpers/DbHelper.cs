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
        private const string DatabaseName = "AceBookDB";

        public const int RequestPending = 0;
        public const int RequestAccepted = 1;
        public const int RequestDeclined = 2;
        
        private static IMongoCollection<BsonDocument> ConnectToDB(string collectionName)
        {
            var connectionString = "mongodb+srv://admin:thelegend27@cluster0-l5nyz.gcp.mongodb.net";

            var client = new MongoClient(MongoUrl.Create(connectionString));

            var database = client.GetDatabase(DatabaseName);

            return database.GetCollection<BsonDocument>(collectionName);
        }

        public static void ClearCollection(string collectionName)
        {
            var connectionString = "mongodb+srv://admin:thelegend27@cluster0-l5nyz.gcp.mongodb.net";

            var client = new MongoClient(MongoUrl.Create(connectionString));

            var database = client.GetDatabase(DatabaseName);

            database.DropCollection(collectionName);
        }

        public static void RegisterUser(string firstName, string lastName, string email, string password, string phoneNumber, string birthDate, string gender)
        {
            var collection = ConnectToDB("user");
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

        public static BsonDocument GetUserByEmail(string email)
        {
            var collection = ConnectToDB("user");
            return collection.Find(new BsonDocument("email", email)).First();
        }

        public static void SetPost(string userId, string message, string datePosted)
        {
            var collection = ConnectToDB("post");
            var document = new BsonDocument
            {
                { "userId", userId },
                { "message", message },
                { "datePosted", datePosted }
            };

            collection.InsertOneAsync(document);
        }

        public static List<BsonDocument> GetPost()
        {
            var collection = ConnectToDB("post");
            return collection.Find(new BsonDocument()).ToList();
        }


        public static void AddFriend(string requesterEmail, string receiverEmail)
        {
            var collection = ConnectToDB("friend");
            var document = new BsonDocument
            {
                { "requesterEmail", requesterEmail },
                { "receiverEmail", receiverEmail },
                { "status", RequestPending }
            };

            collection.InsertOneAsync(document);
        }

        public static void SetFriendRequestStatus(BsonObjectId id, int newStatus)
        {
            var collection = ConnectToDB("friend");

            collection.UpdateOneAsync(
                Builders<BsonDocument>.Filter.Eq("_id", id),
                Builders<BsonDocument>.Update.Set("status", newStatus)
            );
        }

        public static List<BsonDocument> GetOutgoingFriendRequests(string requesterEmail)
        {
            var collection = ConnectToDB("friend");
            return collection.Find(new BsonDocument("requesterEmail", requesterEmail)).ToList();
        }

        public static List<BsonDocument> GetIncomingFriendRequests(string receiverEmail)
        {
            var collection = ConnectToDB("friend");
            return collection.Find(
                Builders<BsonDocument>.Filter.Eq("receiverEmail", receiverEmail) &
                Builders<BsonDocument>.Filter.Eq("status", RequestPending)).ToList();
        }

        public static List<BsonDocument> GetUserByName()
        {
            var collection = ConnectToDB("user");
            return collection.Find(new BsonDocument()).ToList();
        }
    }
}
