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
                    // bu kısımda analiz hesaplamalrı yapılcak 
                    //double boyMetre = model.AdultCustomer.Size / 100.0;
                    //double vki = model.AdultCustomer.Kilo / (boyMetre * boyMetre);
                    //// VKİ'ye dayalı vücut yağ oranı tahmini
                    //double vucutYagOrani = 0;
                    //double bmh = 0;
                    //string vki_comment;
                    //// VKİ değerini yorumlayın

                   
                    //    if (model.AdultCustomer.Gender.Equals("Erkek"))
                    //    {
                    //        vucutYagOrani = 1.20 * vki + 0.23 * Convert.ToDouble(model.AdultCustomer.Age) - 16.2;
                    //        bmh = 88.362 + (13.397 * Convert.ToDouble(model.AdultCustomer.Kilo)) + (4.799 * Convert.ToDouble(model.AdultCustomer.Size)) - (5.677 * Convert.ToDouble(model.AdultCustomer.Age));
                        
                    //    }
                    //    else if (model.AdultCustomer.Gender.Equals("Kadın"))
                    //    {
                    //        vucutYagOrani = 1.20 * vki + 0.23 * Convert.ToDouble(model.AdultCustomer.Age) - 5.4;
                    //        bmh = 447.593 + (9.247 * Convert.ToDouble(model.AdultCustomer.Kilo)) + (3.098 * Convert.ToDouble(model.AdultCustomer.Size)) - (4.330 * Convert.ToDouble(model.AdultCustomer.Age));
                    //    }
                   


                    //if (vki < 18.5)
                    //{
                    //    vki_comment = "Zayıf";
                       
                    //}
                    //else if (vki >= 18.5 && vki <= 24.9)
                    //{
                    //    vki_comment = "Normal";
                    //}
                    //else if (vki >= 25 && vki <= 29.9)
                    //{
                    //    vki_comment = "Fazla kilolu";
                        
                    //}
                    //else if (vki >= 30 && vki <= 34.9)
                    //{
                    //    vki_comment = "Obez (Tip I)";
                    //}
                    //else if (vki >= 35 && vki <= 39.9)
                    //{
                    //    vki_comment = "Obez (Tip II)";
                    //}
                    //else
                    //{
                    //    vki_comment = "İleri derecede obez (Tip III)"; 
                    //}

                    //var customerrow = _customerService.GetList().Data.OrderByDescending(c => c.AdultCustomerID).FirstOrDefault();
                    //model.AdultCustomerDetail.AdultCustomerID = customerrow.AdultCustomerID;
                    //model.AdultCustomerDetail.BMH_value =Convert.ToDecimal(bmh);
                    //model.AdultCustomerDetail.Vki_comment = vki_comment;
                    //model.AdultCustomerDetail.Vki_value = Convert.ToDecimal(vki);
                    //model.AdultCustomerDetail.BodyFatIndex = Convert.ToDecimal(vucutYagOrani);
                    //_customerDetailService.Add(model.AdultCustomerDetail);
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
    }
}
