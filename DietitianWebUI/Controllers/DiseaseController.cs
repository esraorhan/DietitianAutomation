using Business.Abstract;
using DietitianWebUI.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DietitianWebUI.Controllers
{
    public class DiseaseController : Controller
    {
        private IDiseaseService _diseaseService;

        public DiseaseController(IDiseaseService diseaseService)
        {
            _diseaseService = diseaseService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(DiseaseViewModel model)
        {
            model.Disease.DiseaseName = model.Disease.DiseaseName.ToUpper();
            var disease = _diseaseService.Add(model.Disease);
            if (disease.Success == true)
            {
                TempData.Add("message", disease.Message);

            }
            else
            {
                TempData.Add("errormessage", disease.Message);
            }
            return RedirectToAction("Index");
        }
    }
}
