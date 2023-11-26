using Business.Abstract;
using DietitianWebUI.Models;
using Entities.Concrete;
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
            var dietlist = _dietPlanService.GetDietPlanListByMealGroupDto(dietItemId).Data;
            var model = new DietPlanViewModel
            {
                DietItemId = dietItemId,
                dietPlansListByMeals = dietlist
            };
            return View(model);
        }

        public IActionResult AddMeal(int dietItemId)
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
            Text = c.FoodName + " " + c.Amount + " " + c.UnitOfMeasure + " = " + c.Calorie + "Kalori",
            Value = c.FoodID.ToString()
        }).ToList()
        : new List<SelectListItem>();
            var model = new DietPlanViewModel
            {
                Meals = meals,
                Foods = foods,
                DietItemId = dietItemId
            };

            return PartialView("AddMealModal", model);
        }

        public IActionResult CalculationByFood(int FoodId, int Amount)
        {
            var food = _foodService.GetById(FoodId).Data;
            Dictionary<string, decimal?> foodvalues = new Dictionary<string, decimal?>();
            if (Amount > 0)
            {
                foodvalues.Add("Karbonhidrat", food.Carbohydrate * Amount);
                foodvalues.Add("Kalori", food.Calorie * Amount);
                foodvalues.Add("Yag", food.Oil * Amount);
                foodvalues.Add("Protein", food.Protein * Amount);
            }
            return Json(new { jsonlist = foodvalues });
        }
        [HttpPost]
        public IActionResult AddMeal([FromBody] List<DietPlanModel> plans)
        {
            foreach (var item in plans)
            {
                _dietPlanService.Add(new DietPlan
                {
                    Amount = item.Amount,
                    Calorie = item.Calorie,
                    Carbohydrate = item.Carbohydrate,
                    DietItemId = item.DietItemId,
                    FoodID = item.FoodID,
                    MealID = item.MealID,
                    Oil = item.Oil,
                    Protein = item.Protein,
                    UnitOfMeasure = item.UnitOfMeasure,
                    Description =item.Description
                });
            }
            TempData.Add("message", "Başarılı Şekilde Eklendi");
            string Location = "/DietPlans/Index/" + plans[0].DietItemId;
            return Json(new { Locationhref = Location });
            //return Redirect("/DietPlans/Index/" + plans[0].DietItemId);
        }

        [HttpGet("/DietPlans/DeleteDietPlanItem/{dietPlanId}")]
        public IActionResult DeleteDietPlanItem(int dietPlanId)
        {
            var dietItem = _dietPlanService.GetById(dietPlanId).Data;
            var result = _dietPlanService.Delete(dietItem);
            if (result.Success == true)
            {
                TempData.Add("message", "Başarıyla Silindi");

            }
            else
            {
                TempData.Add("errormessage", result.Message);
            }

            return Redirect("/DietPlans/Index/"+dietItem.DietItemId);
        }
    }
}
