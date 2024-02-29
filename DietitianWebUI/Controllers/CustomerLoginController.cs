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
    public class CustomerLoginController : Controller
    {
        private IAdultCustomerService _customerService;

        public CustomerLoginController(IAdultCustomerService customerService)
        {
            _customerService = customerService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string phone, string password)
        {
            var customer = _customerService.GetByPhoneNumber(phone).Data;
            if (customer != null)
            {
                if (customer.Password == password)
                {
                    var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Email,customer.Mail),
                    new Claim(ClaimTypes.Name,customer.FullName),
                    new Claim(ClaimTypes.NameIdentifier,customer.AdultCustomerID.ToString()),
                    new Claim(ClaimTypes.Role,"Müşteri")
                };
                    var userIdentity = new ClaimsIdentity(claims, "AuthClaimsOrnek");
                    ClaimsPrincipal principal = new ClaimsPrincipal(userIdentity);
                    HttpContext.SignInAsync(principal);
                    TempData["message"] = "Şifre Doğru! Sayfaya Yönlendiriliyorsunuz...";
                    return RedirectToAction("Index", "CustomerPage");
                }
                else
                {
                    TempData["errormessage"] = "Şifreniz Yanlış! ";
                    return Redirect("Index");
                }
            }
            else
            {
                TempData["errormessage"] = "Kullanıcı Bulunamadı! ";
                return Redirect("Index");
            }
        }

        public IActionResult LogOut()
        {
            // Mevcut kullanıcının kimlik bilgilerini temizleme
            HttpContext.SignOutAsync();

            return RedirectToAction("Index", "CustomerLogin");
        }
    }
}
