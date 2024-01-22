using Business.Abstract;
using DietitianWebUI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace DietitianWebUI.Controllers
{
    public class AppointmentsController : Controller
    {
        private IAdultCustomerService _customerService;
        
        private IAppoinmentCalendarService _calendarService;

        public AppointmentsController(IAdultCustomerService customerService, IAppoinmentCalendarService calendarService)
        {
            _customerService = customerService;
            _calendarService = calendarService;
        }

        public IActionResult Index()
        {
            var userid = Convert.ToInt32(HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier));
            var filteredList = _calendarService.GetList(userid).Data.Where(c=>c.start>= DateTime.Now && c.start<= DateTime.Now.AddDays(7)).ToList();
            var model = new AppoinmentCalendarViewModel
            {
               AppoinmentCalendars = filteredList
            };
            return View(model);
        }

        [HttpPost("/Appointments/GetData")]
        public IActionResult GetData()
        {
            //var form = HttpContext.Request.Form;
            //var startDate = DateTime.Parse(form["start"]);
            //var endDate = DateTime.Parse(form["end"]);
            //var filteredList = Events.Where(x => startDate <= x.start && x.end <= endDate).ToList();
            var userid = Convert.ToInt32(HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier));
            var filteredList = _calendarService.GetList(userid);
            return Json(filteredList);
        }
        [HttpGet]
        public IActionResult Add()
        {
            var userid = Convert.ToInt32(HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier));
            var customers = _customerService.GetList(userid).Success == true ? _customerService.GetList(userid).Data : null;
            List<SelectListItem> customerlist = customers != null
         ? customers.Select(c => new SelectListItem
         {
             Text = c.FullName,
             Value = c.AdultCustomerID.ToString()
         }).ToList()
         : new List<SelectListItem>();

            var model = new AppoinmentCalendarViewModel
            {
                Customers = customerlist
            };
            return PartialView("AddAppointmentModal",model);
        }

        [HttpPost]
        public IActionResult Add(AppoinmentCalendarViewModel model)
        {
           
            if (model.AppoinmentCalendar !=null)
            {
                model.AppoinmentCalendar.UserId= Convert.ToInt32(HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier));
                var appointment = _calendarService.Add(model.AppoinmentCalendar);

                if (appointment.Success == true)
                {
                    TempData.Add("message", appointment.Message);

                }
                else
                {
                    TempData.Add("errormessage", appointment.Message);
                }
            }
          
            return Redirect("/Appointments/Index");
            //return View("Index");
        }
        [HttpGet("/Appointments/Edit/{id}")]
        public IActionResult Edit(int id)
        {
            var userid = Convert.ToInt32(HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier));
            var customers = _customerService.GetList(userid).Success == true ? _customerService.GetList(userid).Data : null;
            List<SelectListItem> customerlist = customers != null
         ? customers.Select(c => new SelectListItem
         {
             Text = c.FullName,
             Value = c.AdultCustomerID.ToString()
         }).ToList()
         : new List<SelectListItem>();

           
            var appoinment = _calendarService.GetById(id).Data;
            var model = new AppoinmentCalendarViewModel
            {
                 AppoinmentCalendar = appoinment,
                Customers = customerlist
            };
            return PartialView("EditAppoinmentViewModal", model);
        }
        [HttpPost]
        public IActionResult Edit(AppoinmentCalendarViewModel model)
        {
            var result = _calendarService.Update(model.AppoinmentCalendar);
            if (result.Success == true)
            {
                TempData.Add("message", result.Message);

            }
            else
            {
                TempData.Add("errormessage", result.Message);
            }
            return Redirect("/Appointments/Index");
        }
        [HttpGet("/Appointments/Delete/{id}")]
        public IActionResult Delete(int id)
        {
            var app = _calendarService.GetById(id).Data;
            var result = _calendarService.Delete(app);
            if (result.Success == true)
            {
                TempData.Add("message", result.Message);

            }
            else
            {
                TempData.Add("errormessage", result.Message);
            }
            return Redirect("/Appointments/Index");
        }


    }
}
