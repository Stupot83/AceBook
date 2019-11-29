using System;
using System.Collections.Generic;
using AceBook.Helpers;
using MongoDB.Bson;

namespace AceBook.Models
{
    public class Post
    {
        public string UserId { get; set; }
        public string Message { get; set; }
        public string DatePosted { get; set; }

        public static Post PostStatus(string userId, string message, string datePosted)
        {
            DbHelper.SetPost(userId, message, datePosted);
            return new Post
            {
                UserId = userId,
                Message = message,
                DatePosted = datePosted
            };
        }

        public static List<Post> GetAll()
        {
            var data = DbHelper.GetPost();
            var posts = new List<Post> { };
            foreach (BsonDocument post in data)
            {
                posts.Add(new Post
                {
                    UserId = post.GetValue("userId").ToString(),
                    Message = post.GetValue("message").ToString(),
                    DatePosted = post.GetValue("datePosted").ToString()
                }); 
            }
            return posts;
        }
    }
}
