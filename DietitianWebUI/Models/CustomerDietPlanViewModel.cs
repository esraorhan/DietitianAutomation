using Entities.Concrete;
using Entities.Dtos;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DietitianWebUI.Models
{
    public class CustomerDietPlanViewModel
    {
        public IEnumerable<SelectListItem> Meals { get; set; }
        public IEnumerable<SelectListItem> Foods { get; set; }

        public CustomerDietPlan CustomerDietPlan { get; set; }
        public List<CustomerDietPlan> DietPlans { get; set; }
        public int CustomerDietListId { get; set; }
        public List<CustomerDietPlansListByMealGroupDto> CustomerDietPlansListByMeals { get; set; }
    }
}
