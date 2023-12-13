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
    public class CategoryController : Controller
    {
        private ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(CategoryViewModel model)
        {
            CategoryValidator cv = new CategoryValidator();
            ValidationResult result = cv.Validate(model.Category);
            if (result.IsValid)
            {
                model.Category.CategoryName = model.Category.CategoryName.ToUpper();
                var category = _categoryService.Add(model.Category);
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
            //return Redirect("/Category/Index");
            return View("Index");
        }
        [HttpGet("/Category/Edit/{categoryId}")]
        public IActionResult Edit(int categoryId)
        {
            var category = _categoryService.GetById(categoryId).Data;
            var model = new CategoryViewModel
            {
                Category = category
            };
            return PartialView("EditCategoryViewModal", model);
        }
        [HttpPost]
        public IActionResult Edit(CategoryViewModel categoryView)
        {
            var result = _categoryService.Update(categoryView.Category);
            if (result.Success == true)
            {
                TempData.Add("message", result.Message);

            }
            else
            {
                TempData.Add("errormessage", result.Message);
            }
            return Redirect("/Category/Index");
        }

        [HttpGet("/Category/Delete/{categoryId}")]
        public IActionResult Delete(int categoryId)
        {
            var category = _categoryService.GetById(categoryId).Data;
            var result = _categoryService.Delete(category);
            if (result.Success == true)
            {
                TempData.Add("message", "Başarıyla Silindi");

            }
            else
            {
                TempData.Add("errormessage", result.Message);
            }

            return Redirect("/Category/Index");
        }
    }
}
