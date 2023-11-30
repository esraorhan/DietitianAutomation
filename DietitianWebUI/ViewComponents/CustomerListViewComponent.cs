using Business.Abstract;
using DietitianWebUI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DietitianWebUI.ViewComponents
{
    public class CustomerListViewComponent : ViewComponent
    {
        private IAdultCustomerService _customerService;
        private IDiseaseService _diseaseService;

        public CustomerListViewComponent(IAdultCustomerService customerService,IDiseaseService diseaseService)
        {
            _customerService = customerService;
            _diseaseService = diseaseService;
        }

        public IViewComponentResult Invoke()
        {
            var customerList = _customerService.GetList().Data;
            var disease = _diseaseService.GetList().Success == true ? _diseaseService.GetList().Data : null;
            List<SelectListItem> diseases = disease != null
         ? disease.Select(c => new SelectListItem
         {
             Text = c.DiseaseName,
             Value = c.DiseaseId.ToString()
         }).ToList()
         : new List<SelectListItem>();
            var model = new AdultCustomerViewModel
            {
                AdultCustomers = customerList,
                Diseases =diseases
            };
            return View(model);
        }
    }
}
