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
    public class CustomersController : Controller
    {
        private IAdultCustomerService _customerService;

        public CustomersController(IAdultCustomerService customerService)
        {
            _customerService = customerService;
        }


        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(AdultCustomerViewModel model)
        {
            AdultCustomersValidator cv = new AdultCustomersValidator();
            ValidationResult result = cv.Validate(model.AdultCustomer);
            if (result.IsValid)
            {
               
                var category = _customerService.Add(model.AdultCustomer);
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
            return View("Index");
        }
    }
}
