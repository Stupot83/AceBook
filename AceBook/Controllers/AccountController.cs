using Microsoft.AspNetCore.Mvc;
using AceBook.Helpers;

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
            if (DbHelper.GetUser(email, password))
            {
                return RedirectToAction("Index", "Home");
            }

            return RedirectToAction("Login", "Account");
        }

        public IActionResult LogOut()
        { 
            return RedirectToAction("Index", "Home");
        }
    }
}
