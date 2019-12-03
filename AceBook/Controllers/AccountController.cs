using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System;

namespace AceBook.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Login()
        {
            return View("Login");
        }

        public IActionResult LoginUser(string email, string password)
        {
            try
            {
                var user = Models.User.AuthenticateAndGet(email, password);

                HttpContext.Session.SetString("email", email);
                HttpContext.Session.SetString("userId", user.Id.ToString());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
                return RedirectToAction("Login", "Account");
            }
            
            return RedirectToAction("Index", "Home");
        }

        public IActionResult LogOut()
        { 
            return RedirectToAction("Index", "Home");
        }
    }
}
