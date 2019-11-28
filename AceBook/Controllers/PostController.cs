using System;
using Microsoft.AspNetCore.Mvc;

namespace AceBook.Controllers
{
    public class PostController : Controller
    {
        // GET: /<controller>/
        public IActionResult Index()
        {
            return View("Index");
        }

        [HttpPost]
        public IActionResult PostStatus(
            string userId,
            string message,
            string datePosted
            )
        {
            try
            {
                if (String.IsNullOrEmpty(message))
                {
                    throw new Exception();
                }
                Models.Post newPost = Models.Post.PostStatus(userId, message, datePosted);
                Console.WriteLine(newPost.Message);
                Console.WriteLine("Hurray!");
                return StatusCode(201);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
    }
}
