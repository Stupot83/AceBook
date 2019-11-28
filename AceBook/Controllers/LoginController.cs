using Microsoft.AspNetCore.Mvc;
using AceBook.Helpers;

namespace AceBook.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Login()
        {
            return View();
        }

        public IActionResult LoginUser(string email, string password)
        {
            if (DbHelper.GetUser(email, password))
            {
                return RedirectToAction("Index", "Home");
            }

            return RedirectToAction("Login", "User");
        }

        public IActionResult LogOut()
        { 
            return RedirectToAction("Index", "Home");
        }
    }
}
