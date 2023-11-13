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
    public class DietListsController : Controller
    {
        private IGeneralDietListService _dietListService;

        public DietListsController(IGeneralDietListService dietListService)
        {
            _dietListService = dietListService;
        }

        public IActionResult Index()
        {
            var generaldietlist = _dietListService.GetList(null).Data;
            var model = new GeneralDietListViewModel
            {
                GeneralDietLists =generaldietlist
            };
            return View(model);
        }

        public IActionResult AddGeneralDiet()
        {
            return PartialView("AddGeneralDietModal");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddGeneralDiet(GeneralDietListViewModel model)
        {
            GeneralDietListValidator cv = new GeneralDietListValidator();
            ValidationResult result = cv.Validate(model.GeneralDietList);
            if (result.IsValid)
            {
                model.GeneralDietList.DietName = model.GeneralDietList.DietName.ToUpper();
                model.GeneralDietList.Date = DateTime.Now;
                var category = _dietListService.Add(model.GeneralDietList);
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
            return Redirect("Index");
        }
    }
}
