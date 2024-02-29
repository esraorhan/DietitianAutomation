using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Dtos
{
    public class CustomerDietListByCustomerDto : IDto
    {
        
        public int CustomerDietListId { get; set; }
        public int? AdultCustomerID { get; set; }
        public int? DietItemId { get; set; }
        public string DietName { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public decimal TotalCalories { get; set; }
    }
}
