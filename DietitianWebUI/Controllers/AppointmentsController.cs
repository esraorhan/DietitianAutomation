using DietitianWebUI.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DietitianWebUI.Controllers
{
    public class AppointmentsController : Controller
    {
        private static List<Event> Events;
        public AppointmentsController()
        {
            Events = new List<Event>();
            Events.Add(new Event
            {
                title = $"Toplantı",
                allDay = true,
                end = DateTime.Now.AddDays(2),
                start =DateTime.Now
            });
            Events.Add(new Event
            {
                title = $"Yemek",
                allDay = true,
                end = DateTime.Now.AddDays(3),
                start = DateTime.Now,
                color="green"
            });
            Events.Add(new Event
            {
                title = $"danışan randevu",
                allDay = true,
                end = DateTime.Now.AddHours(4),
                start = DateTime.Now,
                color ="blue"
            });
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost("/Appointments/GetData")]
        public IActionResult GetData()
        {
            var form = HttpContext.Request.Form;
            var startDate = DateTime.Parse(form["start"]);
            var endDate = DateTime.Parse(form["end"]);
            var filteredList = Events.Where(x => startDate <= x.start && x.end <= endDate).ToList();
            return Json(filteredList);
        }
    }
}
