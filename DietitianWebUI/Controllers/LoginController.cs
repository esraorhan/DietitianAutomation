using Business.Abstract;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace DietitianWebUI.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        private IUserService _userService;

        public LoginController(IUserService userService)
        {
            _userService = userService;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(string Email, string password)
        {
            var nutritionist = _userService.GetUserList().Data.FirstOrDefault(c => c.Email == Email && c.Password == password && c.Status ==true);
            if (nutritionist !=null)
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Email,nutritionist.Email),
                    new Claim(ClaimTypes.Name,nutritionist.FullName),
                    new Claim(ClaimTypes.NameIdentifier,nutritionist.UserID.ToString()),
                    new Claim(ClaimTypes.Role,nutritionist.RoleName)
                };
                var userIdentity = new ClaimsIdentity(claims, "AuthClaimsOrnek");
                ClaimsPrincipal principal = new ClaimsPrincipal(userIdentity);
                HttpContext.SignInAsync(principal);
                TempData["message"] = "Şifre Doğru! Sayfaya Yönlendiriliyorsunuz...";
                return RedirectToAction("Index", "Category");
            }
            else
            {
                TempData["errormessage"] = "Şifre Yanlış! ";
                return Redirect("Index");
            }
           
        }
        public IActionResult LogOut()
        {
            // Mevcut kullanıcının kimlik bilgilerini temizleme
            HttpContext.SignOutAsync();

            return RedirectToAction("Index", "Login");
        }

        public IActionResult AccessDenied()
        {
            return View();
        }
    }
}
