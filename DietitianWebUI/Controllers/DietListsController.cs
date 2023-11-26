using Business.Abstract;
using Business.ValidationRules;
using DietitianWebUI.Models;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DietitianWebUI.Controllers
{
    public class DietListsController : Controller
    {
        private IGeneralDietListService _dietListService;
        private IAdultCustomerService _customerService;

        public DietListsController(IGeneralDietListService dietListService, IAdultCustomerService customerService)
        {
            _dietListService = dietListService;
            _customerService = customerService;
        }

        public IActionResult Index()
        {
            var generaldietlist = _dietListService.GetList().Data;
            var model = new GeneralDietListViewModel
            {
                GeneralDietLists =generaldietlist
            };
            return View(model);
        }

        public IActionResult AddGeneralDiet()
        {
            var customers =_customerService.GetList().Success == true ? _customerService.GetList().Data : null;
            List<SelectListItem> customerlist = customers != null
         ? customers.Select(c => new SelectListItem
         {
             Text = c.FullName ,
             Value = c.AdultCustomerID.ToString()
         }).ToList()
         : new List<SelectListItem>();

            var model = new GeneralDietListViewModel
            {
                Customers = customerlist
            };
            return PartialView("AddGeneralDietModal",model);
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
        [HttpGet("/DietLists/Edit/{dietItemId}")]
        public IActionResult Edit(int dietItemId)
        {
            var dietTemplate = _dietListService.GetById(dietItemId).Data;
            var customers = _customerService.GetList().Success == true ? _customerService.GetList().Data : null;
            List<SelectListItem> customerlist = customers != null
         ? customers.Select(c => new SelectListItem
         {
             Text = c.FullName,
             Value = c.AdultCustomerID.ToString()
         }).ToList()
         : new List<SelectListItem>();
            var model = new GeneralDietListViewModel
            {
                GeneralDietList = dietTemplate,
                 Customers=customerlist
            };
            return PartialView("EditViewModal",model);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(GeneralDietListViewModel model)
        {
            var result = _dietListService.Update(model.GeneralDietList);
            if (result.Success == true)
            {
                TempData.Add("message", result.Message);

            }
            else
            {
                TempData.Add("errormessage", result.Message);
            }
            return Redirect("/DietLists/Index");
        }
    }
}
