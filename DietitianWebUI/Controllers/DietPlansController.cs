using Business.Abstract;
using DietitianWebUI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DietitianWebUI.Controllers
{
    public class DietPlansController : Controller
    {
        private IFoodService _foodService;
        private IMealService _mealService;
        private IDietPlanService _dietPlanService;

        public DietPlansController(IFoodService foodService, IMealService mealService, IDietPlanService dietPlanService)
        {
            _foodService = foodService;
            _mealService = mealService;
            _dietPlanService = dietPlanService;
        }

        [HttpGet("/DietPlans/Index/{dietItemId}")]
        public IActionResult Index(int dietItemId)
        {           
            return View();
        }

        public IActionResult AddMeal()
        {
            var meal = _mealService.GetList().Success == true ? _mealService.GetList().Data : null;
            List<SelectListItem> meals = meal != null
         ? meal.Select(c => new SelectListItem
         {
             Text = c.MealName + "    -    " + c.MealTime,
             Value = c.MealID.ToString()
         }).ToList()
         : new List<SelectListItem>();

            var food = _foodService.GetFoodListByCategories().Success == true ? _foodService.GetFoodListByCategories().Data : null;
            List<SelectListItem> foods = food != null
        ? food.Select(c => new SelectListItem
        {
            Text = c.FoodName+" " + c.Amount + " " + c.UnitOfMeasure + " = " + c.Calorie + "Kalori",
            Value = c.FoodID.ToString()
        }).ToList()
        : new List<SelectListItem>();
            var model = new DietPlanViewModel
            {
                Meals = meals,
                Foods =foods
            };

            return PartialView("AddMealModal",model);
        }
    }
}
