using System;
using AceBook.Helpers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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

        public IActionResult Profile()
        {
            return View("Profile");
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

        [HttpPost]
        public IActionResult AcceptFriend(string requesterEmail)
        {
            DbHelper.SetFriendRequestStatus(requesterEmail, DbHelper.RequestAccepted);

            return Ok();
        }
    }
}