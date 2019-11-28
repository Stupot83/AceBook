using System;
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
    }
}