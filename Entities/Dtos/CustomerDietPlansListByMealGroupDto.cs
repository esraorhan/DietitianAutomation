using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Dtos
{
    public class CustomerDietPlansListByMealGroupDto : IDto
    {
        public string MealName { get; set; }
        public string MealTime { get; set; }

        public int MealID { get; set; }
        public decimal SumCalorie { get; set; }

        public List<CustomerDietPlandtosGroupedDto> CustomerDietPlandtosGrouped{ get; set; }
    }

    public class CustomerDietPlandtosGroupedDto
    {
        public string HowManyDaysGroup { get; set; }
        public List<CustomerDietPlanDto>  CustomerDietPlanDtos { get; set; }
    }
    public class CustomerDietPlanDto 
    {
        public int CustomerDietPlanId { get; set; }
        public decimal Amount { get; set; }
        public string UnitOfMeasure { get; set; }
        public decimal Calorie { get; set; }
        public decimal Carbohydrate { get; set; }
        public decimal Oil { get; set; }
        public decimal Protein { get; set; }
        public int MealID { get; set; }
        public int FoodID { get; set; }
        public int CustomerDietListId { get; set; }
        public string Description { get; set; }
        public string HowManyDays { get; set; }
        public string FoodName { get; set; }
    }
}
