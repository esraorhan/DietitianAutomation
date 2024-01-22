using Business.Abstract;
using Business.ValidationRules;
using DietitianWebUI.Models;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DietitianWebUI.Controllers
{
    [Authorize(Roles = "Admin,Diyetisyen")]
    public class FoodController : Controller
    {
        private IFoodService _foodService;
        private ICategoryService _categoryService;

        public FoodController(IFoodService foodService, ICategoryService categoryService)
        {
            _foodService = foodService;
            _categoryService = categoryService;
        }

        public IActionResult Index()
        {
            var result = _categoryService.GetList().Success == true ? _categoryService.GetList().Data : null;
            List<SelectListItem> categories = result != null
         ? result.Select(c => new SelectListItem
         {
             Text = c.CategoryName,
             Value = c.CategoryID.ToString()
         }).ToList()
         : new List<SelectListItem>();
            var model = new FoodViewModal
            {
                Categories = categories
            };
            return View(model);
        }

        [HttpPost]
        public IActionResult Add(FoodViewModal model)
        {
           
            FoodValidator cv = new FoodValidator();
            ModelState.Clear();
            ValidationResult result = cv.Validate(model.Food);
            if (result.IsValid)
            {
                model.Food.FoodName = model.Food.FoodName.ToUpper();
                var category = _foodService.Add(model.Food);
                if (category.Success == true)
                {
                    TempData.Add("message", category.Message);

                }
                else
                {
                    TempData.Add("errormessage", category.Message);
                }
            }
            else
            {
                foreach (var item in result.Errors)
                {

                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            var r = _categoryService.GetList().Success == true ? _categoryService.GetList().Data : null;
            List<SelectListItem> categories = r != null
         ? r.Select(c => new SelectListItem
         {
             Text = c.CategoryName,
             Value = c.CategoryID.ToString()
         }).ToList()
         : new List<SelectListItem>();
            model.Categories = categories;
           // model.Food = null; geçici olarak çözdü 
          return View("Index",model);
           //return RedirectToAction("Index");
        }

        [HttpGet("/Food/Edit/{foodId}")]
        public IActionResult Edit(int foodId)
        {
            var food = _foodService.GetById(foodId).Data;
            var result = _categoryService.GetList().Success == true ? _categoryService.GetList().Data : null;
            List<SelectListItem> categories = result != null
         ? result.Select(c => new SelectListItem
         {
             Text = c.CategoryName,
             Value = c.CategoryID.ToString()
         }).ToList()
         : new List<SelectListItem>();
            var model = new FoodViewModal
            {
                Food = food,
                Categories =categories
            };
            return PartialView("EditFoodViewModal", model);
        }
        [HttpPost]
        public IActionResult Edit(FoodViewModal model)
        {
            var result = _foodService.Update(model.Food);
            if (result.Success == true)
            {
                TempData.Add("message", result.Message);

            }
            else
            {
                TempData.Add("errormessage", result.Message);
            }
            return Redirect("/Food/Index");
          
        }

    }
}
