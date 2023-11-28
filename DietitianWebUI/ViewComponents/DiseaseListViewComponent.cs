using Business.Abstract;
using DietitianWebUI.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DietitianWebUI.ViewComponents
{
    public class DiseaseListViewComponent : ViewComponent
    {
        private IDiseaseService _diseaseService;

        public DiseaseListViewComponent(IDiseaseService diseaseService)
        {
            _diseaseService = diseaseService;
        }

        public IViewComponentResult Invoke()
        {
            var diseases = _diseaseService.GetList().Data;
            var model = new DiseaseViewModel
            {
                Diseases = diseases
            };
            return View(model);
        }
    }
}
