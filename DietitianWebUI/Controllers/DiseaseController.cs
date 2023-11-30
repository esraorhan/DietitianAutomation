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
        [HttpGet("/Disease/Edit/{diseaseId}")]
        public IActionResult Edit(int diseaseId)
        {
            var disease = _diseaseService.GetById(diseaseId).Data;
            var model = new DiseaseViewModel
            {
                Disease = disease
            };
            return View(model);
        }

        [HttpPost]
        public IActionResult Edit(DiseaseViewModel model)
        {
            var result = _diseaseService.Update(model.Disease);
            if (result.Success == true)
            {
                TempData.Add("message", result.Message);

            }
            else
            {
                TempData.Add("errormessage", result.Message);
            }
            return Redirect("/Disease/Index");
           
        }

        [HttpGet("/Disease/Delete/{diseaseId}")]
        public IActionResult Delete(int diseaseId)
        {
            var disease = _diseaseService.GetById(diseaseId).Data;
            var result = _diseaseService.Delete(disease);
            if (result.Success == true)
            {
                TempData.Add("message", result.Message);

            }
            else
            {
                TempData.Add("errormessage", result.Message);
            }

            return Redirect("/Disease/Index");
        }
    }
}
