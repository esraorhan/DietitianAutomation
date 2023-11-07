using Business.Abstract;
using DietitianWebUI.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DietitianWebUI.ViewComponents
{
    public class CustomerListViewComponent : ViewComponent
    {
        private IAdultCustomerService _customerService;

        public CustomerListViewComponent(IAdultCustomerService customerService)
        {
            _customerService = customerService;
        }

        public IViewComponentResult Invoke()
        {
            var customerList = _customerService.GetList().Data;
            var model = new AdultCustomerViewModel
            {
                AdultCustomers = customerList
            };
            return View(model);
        }
    }
}
