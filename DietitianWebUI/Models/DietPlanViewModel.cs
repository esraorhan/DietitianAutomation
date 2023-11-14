using Entities.Concrete;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DietitianWebUI.Models
{
    public class DietPlanViewModel
    {
        public IEnumerable<SelectListItem> Meals { get; set; }
        public IEnumerable<SelectListItem> Foods { get; set; }

        public DietPlan DietPlan { get; set; }
        public List<DietPlan> DietPlans { get; set; }
        public int DietItemId { get; set; }
    }
}
