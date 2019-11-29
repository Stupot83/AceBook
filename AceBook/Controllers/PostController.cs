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
            Console.WriteLine("we're here");
            try
            {
                if (String.IsNullOrEmpty("dsfgrny"))
                {
                    throw new Exception();
                }
                Models.Post newPost = Models.Post.PostStatus("dsfgrny", "dsfgrny", "dsfgrny");
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
