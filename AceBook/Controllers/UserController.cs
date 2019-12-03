using System;
using AceBook.Helpers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AceBook.Models;

namespace AceBook.Controllers
{
    public class UserController : Controller
    {
        // GET
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Register()
        {
            return View("Register");
        }

        [Route("user/profile/{userId}")]
        public IActionResult Profile(string userId)
        {
            ViewData["userId"] = userId;
            return View("Profile");
        }

        public IActionResult FriendRequest()
        {
            return View("FriendRequest");
        }

        [HttpPost]
        public IActionResult Register(
            string firstName,
            string lastName,
            string email,
            string password,
            string confirmPassword,
            string phoneNumber,
            string birthDate,
            string gender)
        {
            try
            {
                Models.User newUser = Models.User.Register(firstName, lastName, email, password, confirmPassword, phoneNumber, birthDate, gender);
                Console.WriteLine(newUser.Email);
                Console.WriteLine("Hurray!");
            }
            catch (Exception)
            {
                return BadRequest();
            }
            return Redirect("/home");    
        }

        [HttpPost]
        public IActionResult AddFriend(string receiverEmail)
        {
            var email = HttpContext.Session.GetString("email");
            DbHelper.AddFriend(email, receiverEmail);
            Console.Write(email);

            return Ok();
        }

        [HttpGet]
        public IActionResult AcceptFriend(string requestId)
        {
            Friend.AcceptFriend(requestId);

            return Redirect("/User/FriendRequest");
        }

        [HttpGet]
        public IActionResult DeclineFriend(string requestId)
        {
            Friend.DeclineFriend(requestId);

            return Redirect("/User/FriendRequest");
        }
    }
}