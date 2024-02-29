using Business.Abstract;
using DietitianWebUI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace DietitianWebUI.Controllers
{
    [Authorize(Roles = "Müşteri")]
    public class CustomerPageController : Controller
    {
       
        private IAdultCustomerDetailService _customerDetailService;
        private IDiseaseService _diseaseService;
        private IAdultMeetingService _adultMeetingService;
        private ICustomerDietListService _customerDietListService;
        private ICustomerDietPlanService _customerDietPlanService;
        public CustomerPageController(IAdultCustomerDetailService customerDetailService, IDiseaseService diseaseService,IAdultMeetingService adultMeetingService,
            ICustomerDietListService customerDietListService, ICustomerDietPlanService customerDietPlanService)
        {
            _customerDetailService = customerDetailService;
            _diseaseService = diseaseService;
            _adultMeetingService = adultMeetingService;
            _customerDietListService = customerDietListService;
            _customerDietPlanService = customerDietPlanService;
        }

        public IActionResult Index()
        {
            var customerId = Convert.ToInt32(HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier));
            ////ViewBag.id = HttpContext.Session.GetString("danisanbilsi");
            var customerinformation = _customerDetailService.GetDetailCustomer(customerId).Data;
            var customersDiseaseList = _diseaseService.GetListDiseasesByCustomers(customerId).Data;

            var CustomerDietListId = _customerDietListService.GetCustomerDietListDescFirst(customerId).Data.AdultCustomerID ?? 0; 
            var dietlist = _customerDietPlanService.GetCustomerDietPlanListByMealGroupDto(CustomerDietListId).Data;
            var model = new CustomerPageViewModel
            { 
                AdultCustomerDetail = customerinformation,
                Diseases = customersDiseaseList,
                CustomerDietPlansListByMeals =dietlist
            };
            return View(model);
           
        }

        //danışan grafiklerini göstermek için 
        public IActionResult Graphics(int customerId)
        {
            var values = _adultMeetingService.GetList(customerId).Data.Select(c => new
            {
                kilo = c.UpdateKilo,
                kalca = c.HaunchSize,
                bel = c.WaistSize,
                yagoranı = c.FatRate,
                tarih = c.MeetingDate.ToShortDateString()
            }).ToList();
            var kiloArray = values.Select(v => new { tarih = v.tarih, deger = v.kilo }).ToList();
            var yagOraniArray = values.Select(v => new { tarih = v.tarih, deger = v.yagoranı }).ToList();
            var kalcaarray = values.Select(v => new { tarih = v.tarih, deger = v.kalca }).ToList();
            var belarray = values.Select(v => new { tarih = v.tarih, deger = v.bel }).ToList();

            return Json(new { kilo = kiloArray, yagOrani = yagOraniArray, kalca = kalcaarray, bel = belarray });
        }
    }
}
