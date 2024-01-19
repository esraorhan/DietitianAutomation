using Entities.Concrete;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DietitianWebUI.Models
{
    public class AppoinmentCalendarViewModel
    {
        public AppoinmentCalendar AppoinmentCalendar { get; set; }
        public List<AppoinmentCalendar> AppoinmentCalendars { get; set; }
        public IEnumerable<SelectListItem> Customers { get; set; }
    }
}
