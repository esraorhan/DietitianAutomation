using Business.Abstract;
using Business.ValidationRules;
using DietitianWebUI.Models;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DietitianWebUI.Controllers
{
    public class MealController : Controller
    {
        private IMealService _mealService;

        public MealController(IMealService mealService)
        {
            _mealService = mealService;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Add(MealViewModel model)
        {
            MealValidator cv = new MealValidator();
            ValidationResult result = cv.Validate(model.Meal);
            if (result.IsValid)
            {
                model.Meal.MealName = model.Meal.MealName.ToUpper();
                var meal = _mealService.Add(model.Meal);
                if (meal.Success == true)
                {
                    TempData.Add("message", meal.Message);

                }
                else
                {
                    TempData.Add("errormessage", meal.Message);
                }
            }
            else
            {
                foreach (var item in result.Errors)
                {

                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            //return Redirect("/Category/Index");
            return View("Index");
        }

        [HttpGet("/Meal/Edit/{mealId}")]
        public IActionResult Edit(int mealId)
        {
            var meal = _mealService.GetById(mealId).Data;
            var model = new MealViewModel
            {
                Meal = meal
            };
            return PartialView("EditMealViewModal", model);
        }
        [HttpPost]
        public IActionResult Edit(MealViewModel mealView)
        {

            var result = _mealService.Update(mealView.Meal);
            if (result.Success == true)
            {
                TempData.Add("message", result.Message);

            }
            else
            {
                TempData.Add("errormessage", result.Message);
            }
            return Redirect("/Meal/Index");
        }
    }
}
