using Business.Abstract;
using DietitianWebUI.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DietitianWebUI.ViewComponents
{
    public class CustomerProfileInformationViewComponent : ViewComponent
    {
        private IAdultCustomerDetailService _customerDetailService;

        public CustomerProfileInformationViewComponent(IAdultCustomerDetailService  customerDetailService)
        {
            _customerDetailService = customerDetailService;
        }

        public IViewComponentResult Invoke(int CustomerId)
        {
            var customerinformation = _customerDetailService.GetDetailCustomer(CustomerId).Data;
            var model = new CustomerProfileViewModel
            {
               AdultCustomerDetail =customerinformation
                // CourseId = CourseId
            };
            return View(model);
          
        }

    }
}
