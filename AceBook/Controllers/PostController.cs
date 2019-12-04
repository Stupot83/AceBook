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
            string message
            )
        {
            try
            {
                if (string.IsNullOrEmpty(message))
                {
                    throw new Exception();
                }
                var date = DateTime.Now.ToString("dd/MM/yyyy");
                Models.Post newPost = Models.Post.PostStatus(userId, message, date);
                Console.WriteLine(newPost.Message);
                Console.WriteLine("Hurray!");
                return RedirectToAction("Index", "Home");
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
    }
}
