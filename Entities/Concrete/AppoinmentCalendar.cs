using Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class AppoinmentCalendar :IEntity
    {
        [Key]
        
        public int id { get; set; }
        public int? AdultCustomerId { get; set; }
        public int? UserId { get; set; }
        public string title { get; set; }
        public DateTime start { get; set; }
        public DateTime end { get; set; }
        public string color { get; set; }
        public bool allDay { get; set; }
    }
}
