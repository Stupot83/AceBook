using System;
using System.Collections.Generic;
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
            return GetIncomingRequest(receiverEmail).Count;
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
    }
}
