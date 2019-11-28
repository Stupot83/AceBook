using System;
using AceBook.Helpers;

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

        public static Post GetStatus(string postId)
        {
            var data = DbHelper.GetPost(postId);
            return new Post
            {
                UserId = data.GetValue("userId").ToString(),
                Message = data.GetValue("message").ToString(),
                DatePosted = data.GetValue("datePosted").ToString()
            };
        }
    }
}
