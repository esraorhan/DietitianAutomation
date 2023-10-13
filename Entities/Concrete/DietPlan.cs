using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
   public  class DietPlan:IEntity
    {
        public int DietPlanId { get; set; }
        public decimal Amount { get; set; }
        public string UnitOfMeasure { get; set; }
        public decimal Calorie { get; set; }
        public decimal Carbohydrate { get; set; }
        public decimal Oil { get; set; }
        public int MealID { get; set; }
        public int FoodID { get; set; }
    }
}
