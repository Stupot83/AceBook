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

                HttpContext.Session.SetString("name", $"{user.FirstName} {user.LastName}");
            }
            catch (Exception)
            {
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
