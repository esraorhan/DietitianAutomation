using Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class GeneralDietList:IEntity
    {
        [Key]
        public int DietItemId { get; set; }
        public int? AdultCustomerID { get; set; }
        public string DietName { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public decimal TotalCalories { get; set; }
    }
}
