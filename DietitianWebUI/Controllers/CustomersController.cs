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
        private IAdultCustomerDetailService _customerDetailService;

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
                model.AdultCustomer.StartingDate = DateTime.Now;
                model.AdultCustomer.Age = DateTime.Now.Year - model.AdultCustomer.DateOfBirth.Year;
                var customer = _customerService.Add(model.AdultCustomer);
                if (customer.Success == true)
                {
                   
                    TempData.Add("message", customer.Message);

                }
                else
                {
                    TempData.Add("errormessage", customer.Message);
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

        [HttpGet("/Customers/Edit/{customerId}")]
        public IActionResult Edit(int customerId)
        {
            var customerInformation = _customerService.GetById(customerId).Data;
            var model = new AdultCustomerViewModel
            {
                AdultCustomer = customerInformation
            };
            return PartialView("EditCustomerViewModal", model);
        }

        [HttpPost]
        public IActionResult Edit(AdultCustomerViewModel model)
        {
            var result = _customerService.Update(model.AdultCustomer);
            if (result.Success == true)
            {
                TempData.Add("message", result.Message);

            }
            else
            {
                TempData.Add("errormessage", result.Message);
            }
            return Redirect("/Customers/Index");
        }
    }
}
