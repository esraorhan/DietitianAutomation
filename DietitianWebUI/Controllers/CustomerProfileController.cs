using Business.Abstract;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DietitianWebUI.Controllers
{
    public class CustomerProfileController : Controller
    {
        private IAdultMeetingService _adultMeetingService;
        public IActionResult Index(int customerId)
        {
            return View();
        }
    }
}
