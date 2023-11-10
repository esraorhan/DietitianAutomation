using Business.Abstract;
using DietitianWebUI.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DietitianWebUI.ViewComponents
{
    public class CustomerFolderListViewComponent : ViewComponent
    {
        private ICustomerFolderService _folderService;

        public CustomerFolderListViewComponent(ICustomerFolderService folderService)
        {
            _folderService = folderService;
        }

        public IViewComponentResult Invoke(int customerId)
        {
            var customerfolderList = _folderService.GetList(customerId).Data;
            var model = new CustomerProfileViewModel
            {
                CustomerFolders = customerfolderList
                // CourseId = CourseId
            };
            return View(model);

        }
    }
}
