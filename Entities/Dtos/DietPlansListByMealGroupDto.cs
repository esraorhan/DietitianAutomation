using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Dtos
{
    public class DietPlansListByMealGroupDto :IDto
    {
        public string MealName { get; set; }
        public string MealTime { get; set; }
        public int MealID { get; set; }
        public decimal SumCalorie { get; set; }
       
        public List<DietPlandto> DietPlandtos { get; set; }

    }
    public class DietPlandto
    {
        public int DietPlanId { get; set; }
        public decimal Amount { get; set; }
        public string UnitOfMeasure { get; set; }
        public decimal Calorie { get; set; }
        public decimal Carbohydrate { get; set; }
        public decimal Oil { get; set; }
        public decimal Protein { get; set; }

        public int FoodID { get; set; }
        public int DietItemId { get; set; }
        public string Description { get; set; }
        public string FoodName { get; set; }

        //public string MealTime { get; set; }
    }
}
