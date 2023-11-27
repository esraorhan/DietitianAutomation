using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DietitianWebUI.Models
{
    public class DietPlanModel
    {
        //public int DietPlanId { get; set; }
        public decimal Calorie { get; set; }
        public decimal Protein { get; set; }
        public decimal Carbohydrate { get; set; }
        public decimal Oil { get; set; }
        public int FoodID { get; set; }
        public int MealID { get; set; }
        

        public decimal Amount { get; set; }
        public string Description { get; set; }

        public string UnitOfMeasure { get; set; }
        public string HowManyDays { get; set; }


        public int DietItemId { get; set; }
    }
}
