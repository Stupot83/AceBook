using System;
using System.Collections.Generic;
using System.Linq;
using AceBook.Helpers;
using MongoDB.Bson;

namespace AceBook.Models
{
    public class Friend
    {
        public BsonObjectId Id { get; set; }
        public string RequesterEmail { get; set; }
        public string ReceiverEmail { get; set; }
        public int Status { get; set; }


        public static void AddFriend(string requesterEmail, string receiverEmail)
        {
            DbHelper.AddFriend(requesterEmail, receiverEmail);
        }

        public static void AcceptFriend(string id)
        {
            DbHelper.SetFriendRequestStatus(new BsonObjectId(new ObjectId(id)), DbHelper.RequestAccepted);
        }

        public static void DeclineFriend(string id)
        {
            DbHelper.SetFriendRequestStatus(new BsonObjectId(new ObjectId(id)), DbHelper.RequestDeclined);
        }

        public static int FriendRequestCount(string receiverEmail)
        {
            return GetIncomingRequest(receiverEmail).Where(r => r.Status == 0).ToList().Count;
        }

        public static List<Friend> GetOutgoingRequest(string requesterEmail)
        {
            var data = DbHelper.GetOutgoingFriendRequests(requesterEmail);
            var list = new List<Friend>() { };
            foreach(BsonDocument friend in data)
            {
                list.Add(new Friend
                {
                    Id = (BsonObjectId)friend.GetValue("_id"),
                    ReceiverEmail = (string)friend.GetValue("receiverEmail"),
                    RequesterEmail = (string)friend.GetValue("requesterEmail"),
                    Status = (int)friend.GetValue("status")
                });
            }

            return list;
        }

        public static List<Friend> GetIncomingRequest(string receiverEmail)
        {
            var data = DbHelper.GetIncomingFriendRequests(receiverEmail);
            var list = new List<Friend>() { };
            foreach (BsonDocument friend in data)
            {
                list.Add(new Friend
                {
                    Id = (BsonObjectId)friend.GetValue("_id"),
                    ReceiverEmail = (string)friend.GetValue("receiverEmail"),
                    RequesterEmail = (string)friend.GetValue("requesterEmail"),
                    Status = (int)friend.GetValue("status")
                });
            }

            return list;
        }

        public static List<string> ListFriendIds(string email)
        {
            Console.WriteLine("Looking for requests relating to " + email);
            var incomingRequests = GetIncomingRequest(email).Where(r => r.Status == 1 && r.ReceiverEmail == email).ToList();
            var outgoingRequests = GetOutgoingRequest(email).Where(r => r.Status == 1 && r.RequesterEmail == email).ToList();

            var friendIds = new List<string> { };

            foreach (Friend request in incomingRequests)
            {
                var user = User.GetUserByEmail(request.RequesterEmail);
                friendIds.Add(user.Id.ToString());
            }

            foreach (Friend request in outgoingRequests)
            {
                var user = User.GetUserByEmail(request.ReceiverEmail);
                friendIds.Add(user.Id.ToString());
            }

            return friendIds;
        }
    }
}
