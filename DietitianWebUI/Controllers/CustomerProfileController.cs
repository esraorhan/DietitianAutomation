using Business.Abstract;
using Business.ValidationRules;
using DietitianWebUI.Models;
using FluentValidation.Results;
using Microsoft.AspNetCore.Http;
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
        private IAdultCustomerDetailService _customerDetailService;

        public CustomerProfileController(IAdultMeetingService adultMeetingService, IAdultCustomerDetailService customerDetailService)
        {
            _adultMeetingService = adultMeetingService;
            _customerDetailService = customerDetailService;
        }

        [HttpGet("/CustomerProfile/Index/{customerId}")]
        public IActionResult Index(int customerId)
        {
            HttpContext.Session.SetString("customerId", customerId.ToString());
            ////ViewBag.id = HttpContext.Session.GetString("danisanbilsi");
            var customerinformation = _customerDetailService.GetDetailCustomer(customerId).Data;
            var model = new CustomerProfileViewModel
            {
                AdultCustomerDetail = customerinformation
                // CourseId = CourseId
            };
            return View(model);

        }
        [HttpGet("/CustomerProfile/AddNewMeeting/{customerId}")]
        public IActionResult AddNewMeeting(int customerId)
        {
            var customerinformation = _customerDetailService.GetDetailCustomer(customerId).Data;
            var model = new CustomerProfileViewModel
            {
                AdultCustomerDetail = customerinformation
                // CourseId = CourseId
            };
            return PartialView("AddNewMeetingModal",model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddAddNewMeeting(CustomerProfileViewModel model)
        {
            AdultMeetingValidator cv = new AdultMeetingValidator();
            ValidationResult result = cv.Validate(model.AdultMeeting);
            if (result.IsValid)
            {
                model.AdultMeeting.MeetingDate = DateTime.Now;
                var category = _adultMeetingService.Add(model.AdultMeeting);
                if (category.Success == true)
                {
                    TempData.Add("message", category.Message);

                }
                else
                {
                    TempData.Add("errormessage", category.Message);
                    return PartialView("AddNewMeetingModal", model);
                }
               
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                    //TempData.Add("errormessage", item.ErrorMessage);
                }
            }
            return Redirect("/CustomerProfile/Index/"+ model.AdultMeeting.AdultCustomerID);

        }
        [HttpGet("/CustomerProfile/EditMeeting/{meetingId}")]
        public IActionResult EditMeeting(int meetingId)
        {
            var customermeeting = _adultMeetingService.GetById(meetingId).Data;
            var model = new CustomerProfileViewModel
            {
                AdultMeeting = customermeeting

                // CourseId = CourseId
            };
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EditMeeting(CustomerProfileViewModel model)
        {
            var result = _adultMeetingService.Update(model.AdultMeeting);
            if (result.Success == true)
            {
                TempData.Add("message", result.Message);

            }
            else
            {
                TempData.Add("errormessage", result.Message);
            }
            return Redirect("/CustomerProfile/Index/" + model.AdultMeeting.AdultCustomerID);
        }

  
        public IActionResult DeleteMeeting(int meetingId,int customerId)
        {
            var meeting = _adultMeetingService.GetById(meetingId).Data;
            var result = _adultMeetingService.Delete(meeting);
            if (result.Success == true)
            {
                TempData.Add("message", "Başarıyla Silindi");

            }
            else
            {
                TempData.Add("errormessage", result.Message);
            }

            return Redirect("/CustomerProfile/Index/" + customerId);
        }

        //danışan grafiklerini göstermek için 
        public IActionResult Graphics(int customerId)
        {
            var values = _adultMeetingService.GetList(customerId).Data.Select(c => new
            {
                kilo = c.UpdateKilo,
                kalca =c.HaunchSize,
                bel =c.WaistSize,
                yagoranı =c.FatRate,
                tarih = c.MeetingDate.ToShortDateString()
            }).ToList();
            var kiloArray = values.Select(v => new { tarih = v.tarih, deger = v.kilo }).ToList();
            var yagOraniArray = values.Select(v => new { tarih = v.tarih, deger = v.yagoranı }).ToList();
            var kalcaarray = values.Select(v => new { tarih = v.tarih, deger = v.kalca }).ToList();
            var belarray = values.Select(v => new { tarih = v.tarih, deger = v.bel }).ToList();

            return Json(new { kilo = kiloArray, yagOrani = yagOraniArray, kalca =kalcaarray, bel =belarray });
        }

    }
}
