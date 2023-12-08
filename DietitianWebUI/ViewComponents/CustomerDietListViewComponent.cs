using Business.Abstract;
using DietitianWebUI.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DietitianWebUI.ViewComponents
{
    public class CustomerDietListViewComponent : ViewComponent
    {
        private ICustomerDietListService _customerDietListService;

        public CustomerDietListViewComponent(ICustomerDietListService customerDietListService)
        {
            _customerDietListService = customerDietListService;
        }

        public IViewComponentResult Invoke(int CustomerId)
        {
            var customerDietLists = _customerDietListService.GetList(CustomerId).Data;
            var model = new CustomerProfileViewModel
            {
               CustomerDietLists=customerDietLists
            };
            return View(model);

        }
    }
}
