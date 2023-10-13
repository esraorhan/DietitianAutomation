using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DietitianWebUI.Models
{
    public class MealViewModel
    {
        public Meal Meal { get; set; }
        public List<Meal> Meals { get; set; }
    }
}
