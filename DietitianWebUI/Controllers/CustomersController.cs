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
using System.Security.Claims;
using System.Threading.Tasks;

namespace DietitianWebUI.Controllers
{
    [Authorize(Roles = "Admin,Diyetisyen")]
    public class CustomersController : Controller
    {
        private IAdultCustomerService _customerService;
        //private IAdultCustomerDetailService _customerDetailService;
        private IDiseaseService _diseaseService;

        public CustomersController(IAdultCustomerService customerService,IDiseaseService diseaseService)
        {
            _customerService = customerService;
            _diseaseService = diseaseService;
        }


        public IActionResult Index()
        {
            var disease = _diseaseService.GetList().Success == true ? _diseaseService.GetList().Data : null;
            List<SelectListItem> diseases = disease != null
         ? disease.Select(c => new SelectListItem
         {
             Text = c.DiseaseName ,
             Value = c.DiseaseId.ToString()
         }).ToList()
         : new List<SelectListItem>();

            var model = new AdultCustomerViewModel
            {
                Diseases = diseases,
               
            };
            return View(model);
        }

        [HttpPost]
        public IActionResult Add(AdultCustomerViewModel model,int[] diseaseId)
        {
            AdultCustomersValidator cv = new AdultCustomersValidator();
            ValidationResult result = cv.Validate(model.AdultCustomer);
            if (result.IsValid)
            {
                model.AdultCustomer.StartingDate = DateTime.Now;
                model.AdultCustomer.Age = DateTime.Now.Year - model.AdultCustomer.DateOfBirth.Year;
                model.AdultCustomer.UserRoleID = 3;
                model.AdultCustomer.UserId = Convert.ToInt32(HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier));
                for (int i = 0; i < diseaseId.Length; i++)
                {
                    model.AdultCustomer.DiseaseId += diseaseId[i].ToString()+"-";
                    
                }
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
            return Redirect("/Customers/Index");
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
