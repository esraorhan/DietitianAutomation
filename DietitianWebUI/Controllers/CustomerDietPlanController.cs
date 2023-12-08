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
    public class CustomerDietPlanController : Controller
    {
        private IFoodService _foodService;
        private IMealService _mealService;
        private ICustomerDietPlanService _customerDietPlanService;

        public CustomerDietPlanController(IFoodService foodService, IMealService mealService, ICustomerDietPlanService customerDietPlanService)
        {
            _foodService = foodService;
            _mealService = mealService;
            _customerDietPlanService = customerDietPlanService;
        }

        [HttpGet("/CustomerDietPlan/Index/{CustomerDietListId}")]
        public IActionResult Index(int CustomerDietListId)
        {
            var dietlist = _customerDietPlanService.GetCustomerDietPlanListByMealGroupDto(CustomerDietListId).Data;
            var model = new CustomerDietPlanViewModel
            {
                CustomerDietListId = CustomerDietListId,
                CustomerDietPlansListByMeals = dietlist
            };
            return View(model);
          
        }

        public IActionResult AddMeal(int CustomerDietListId)
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
            var model = new CustomerDietPlanViewModel
            {
                Meals = meals,
                Foods = foods,
                CustomerDietListId = CustomerDietListId
            };

            return PartialView("CustomerAddMealModal", model);
        }

        public IActionResult CalculationByFood(int FoodId, decimal Amount)
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
        public IActionResult AddMeal([FromBody] List<CustomerDietPlanModel> plans)
        {
            foreach (var item in plans)
            {
                _customerDietPlanService.Add(new CustomerDietPlan
                {
                    Amount = item.Amount,
                    Calorie = item.Calorie,
                    Carbohydrate = item.Carbohydrate,
                    CustomerDietListId = item.CustomerDietListId,
                    FoodID = item.FoodID,
                    MealID = item.MealID,
                    Oil = item.Oil,
                    Protein = item.Protein,
                    UnitOfMeasure = item.UnitOfMeasure,
                    Description = item.Description,
                    HowManyDays = item.HowManyDays
                });
            }
            TempData.Add("message", "Başarılı Şekilde Eklendi");
           string Location = "/CustomerDietPlan/Index/" + plans[0].CustomerDietListId;
            return Json(new { Locationhref = Location });
            //return Redirect("/DietPlans/Index/" + plans[0].DietItemId);
        }

        [HttpGet("/CustomerDietPlan/DeleteDietPlanItem/{CustomerDietPlanId}")]
        public IActionResult DeleteDietPlanItem(int CustomerDietPlanId)
        {
            var dietItem = _customerDietPlanService.GetById(CustomerDietPlanId).Data;
            var result = _customerDietPlanService.Delete(dietItem);
            if (result.Success == true)
            {
                TempData.Add("message", "Başarıyla Silindi");

            }
            else
            {
                TempData.Add("errormessage", result.Message);
            }

            return Redirect("/CustomerDietPlan/Index/" + dietItem.CustomerDietListId);
        }
    }
}
