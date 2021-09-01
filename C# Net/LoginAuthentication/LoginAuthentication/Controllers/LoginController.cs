using LoginAuthentication.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;

namespace LoginAuthentication.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(User user)
        {
            UserManager.Register(user);
            return View();
        }

        public IActionResult Authenticate()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Authenticate(User user)
        {
            string msg = string.Empty;
            user = UserManager.Authenticate(user);
            ViewData.Remove("error");
            ViewData.Remove("success");
            if (user == null)
            {
                //not authenticated
                msg = "You have entered invalid credentials";
                ViewData.Add("error", msg);
            }
            else
            {
                msg = "Successful login!";
                ViewData.Add("success", msg);

                //claims based identity
                var claims = new List<Claim>() {
                    new Claim(ClaimTypes.Name, user.Username),
                    new Claim(ClaimTypes.Role, "Client")
                };

                var claimsIdentity = new ClaimsIdentity(claims, "Cookies");
                //authentication ticket created
                await HttpContext.SignInAsync("Cookies",
                    new ClaimsPrincipal(claimsIdentity));
            }
            return View();
        }

        public async Task<IActionResult> LogoutAsync()
        {
            await HttpContext.SignOutAsync("Cookies");
            return RedirectToAction("Index", "Home");
        }
    }
}
