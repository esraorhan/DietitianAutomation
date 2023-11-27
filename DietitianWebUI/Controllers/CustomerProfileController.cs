using Business.Abstract;
using Business.ValidationRules;
using DietitianWebUI.Models;
using FluentValidation.Results;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace DietitianWebUI.Controllers
{
    public class CustomerProfileController : Controller
    {
        private IAdultMeetingService _adultMeetingService;
        private IAdultCustomerDetailService _customerDetailService;
        private ICustomerFolderService _folderService;

        public CustomerProfileController(IAdultMeetingService adultMeetingService, IAdultCustomerDetailService customerDetailService, ICustomerFolderService folderService)
        {
            _adultMeetingService = adultMeetingService;
            _customerDetailService = customerDetailService;
            _folderService = folderService;
        }

        [HttpGet("/CustomerProfile/Index/{customerId}")]
        public IActionResult Index(int customerId)
        {
            HttpContext.Session.SetString("customerId", customerId.ToString());
            ////ViewBag.id = HttpContext.Session.GetString("danisanbilsi");
            var customerinformation = _customerDetailService.GetDetailCustomer(customerId).Data;
            var model = new CustomerProfileViewModel
            {
                AdultCustomerDetail = customerinformation,
                
                // CourseId = CourseId
            };
            return View(model);

        }
        [HttpGet("/CustomerProfile/AddNewMeeting/{customerId}")]
        public IActionResult AddNewMeeting(int customerId)
        {
            var customerinformation = _customerDetailService.GetDetailCustomer(customerId).Data;
            var LastMeeting = _adultMeetingService.GetList(customerId).Data.OrderByDescending(c => c.AdultMeetingID).FirstOrDefault();

            var model = new CustomerProfileViewModel
            {
                AdultCustomerDetail = customerinformation,
                AdultMeeting =LastMeeting

                // CourseId = CourseId
            };
            return PartialView("AddNewMeetingModal",model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddAddNewMeeting(CustomerProfileViewModel model)
        {
            AdultMeetingValidator cv = new AdultMeetingValidator();
            ValidationResult result = cv.Validate(model.AdultMeeting);
            if (result.IsValid)
            {
                model.AdultMeeting.MeetingDate = DateTime.Now;
                var category = _adultMeetingService.Add(model.AdultMeeting);
                if (category.Success == true)
                {
                    TempData.Add("message", category.Message);

                }
                else
                {
                    TempData.Add("errormessage", category.Message);
                    return PartialView("AddNewMeetingModal", model);
                }
               
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                    //TempData.Add("errormessage", item.ErrorMessage);
                }
            }
            return Redirect("/CustomerProfile/Index/"+ model.AdultMeeting.AdultCustomerID);

        }
        [HttpGet("/CustomerProfile/EditMeeting/{meetingId}")]
        public IActionResult EditMeeting(int meetingId)
        {
            var customermeeting = _adultMeetingService.GetById(meetingId).Data;
            var model = new CustomerProfileViewModel
            {
                AdultMeeting = customermeeting

                // CourseId = CourseId
            };
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EditMeeting(CustomerProfileViewModel model)
        {
            var result = _adultMeetingService.Update(model.AdultMeeting);
            if (result.Success == true)
            {
                TempData.Add("message", result.Message);

            }
            else
            {
                TempData.Add("errormessage", result.Message);
            }
            return Redirect("/CustomerProfile/Index/" + model.AdultMeeting.AdultCustomerID);
        }

  
        public IActionResult DeleteMeeting(int meetingId,int customerId)
        {
            var meeting = _adultMeetingService.GetById(meetingId).Data;
            var result = _adultMeetingService.Delete(meeting);
            if (result.Success == true)
            {
                TempData.Add("message", "Başarıyla Silindi");

            }
            else
            {
                TempData.Add("errormessage", result.Message);
            }

            return Redirect("/CustomerProfile/Index/" + customerId);
        }

        //danışan grafiklerini göstermek için 
        public IActionResult Graphics(int customerId)
        {
            var values = _adultMeetingService.GetList(customerId).Data.Select(c => new
            {
                kilo = c.UpdateKilo,
                kalca =c.HaunchSize,
                bel =c.WaistSize,
                yagoranı =c.FatRate,
                tarih = c.MeetingDate.ToShortDateString()
            }).ToList();
            var kiloArray = values.Select(v => new { tarih = v.tarih, deger = v.kilo }).ToList();
            var yagOraniArray = values.Select(v => new { tarih = v.tarih, deger = v.yagoranı }).ToList();
            var kalcaarray = values.Select(v => new { tarih = v.tarih, deger = v.kalca }).ToList();
            var belarray = values.Select(v => new { tarih = v.tarih, deger = v.bel }).ToList();

            return Json(new { kilo = kiloArray, yagOrani = yagOraniArray, kalca =kalcaarray, bel =belarray });
        }

        [HttpGet("/CustomerProfile/AddFolder/{customerId}")]
        public IActionResult AddFolder(int customerId)
        {
            var customerinformation = _customerDetailService.GetDetailCustomer(customerId).Data;
            var model = new CustomerProfileViewModel
            {
                AdultCustomerDetail = customerinformation
                // CourseId = CourseId
            };
            return PartialView("AddFolderModal", model);
        }

        [HttpPost]
        public IActionResult AddFolder(CustomerProfileViewModel model)
        {
            var file = Request.Form.Files["formFile"];
            CustomerFolderValidator cf = new CustomerFolderValidator();
            ValidationResult result = new ValidationResult();
            try
            {
                if (result.IsValid)
                {
                    if (file.ContentType == "image/png" || file.ContentType == "image/jpeg" || file.ContentType == "application/pdf")
                    {
                        var extension = Path.GetExtension(file.FileName);
                        var newvideoname = Path.GetFileNameWithoutExtension(file.FileName.Replace(' ', '_')) + extension;
                        var location = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Folder/", newvideoname);
                        using (var stream = new FileStream(location, FileMode.Create))
                        {
                            file.CopyTo(stream);
                        }
                        model.CustomerFolder.FolderPath = newvideoname;
                        model.CustomerFolder.CreationDate = DateTime.Now;
                        model.CustomerFolder.FolderExtension = extension;
                        var folder = _folderService.Add(model.CustomerFolder);
                        if (folder.Success == true)
                        {
                            TempData.Add("message", folder.Message);
                        }
                        else
                        {
                            TempData.Add("errormessage", folder.Message);
                        }
                    }
                   
                }
                else
                {
                    TempData.Add("errormessage", "Lütfen geçerli   formatta  yükleyin");
                }
            }
            catch (Exception ex)
            {

                throw;
            }
            return Redirect("/CustomerProfile/Index/" + model.CustomerFolder.AdultCustomerID);
        }

        [HttpGet("/CustomerProfile/ShowFolder/{folderId}")]
        public IActionResult ShowFolder(int folderId)
        {
            var folder = _folderService.GetById(folderId).Data;
            var pdfFilePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Folder", folder.FolderPath);

            if (System.IO.File.Exists(pdfFilePath))
            {
                if (folder.FolderExtension==".pdf")
                {
                    var fileBytes = System.IO.File.ReadAllBytes(pdfFilePath);
                    return File(fileBytes, "application/pdf");
                }
                else
                {
                    var fileBytes = System.IO.File.ReadAllBytes(pdfFilePath);
                    return File(fileBytes, "image/png");
                }
               
            }
            else
            {
                return NotFound(); // Dosya bulunamazsa uygun bir hata sayfasına yönlendirilebilir.
            }
            
        }

        [HttpGet("/CustomerProfile/DeleteFolder/{folderId}/{customerId}")]
        public ActionResult Delete(int folderId, int customerId)
        {
            var foldercontent = _folderService.GetById(folderId).Data;


            // Veritabanından video adını veya kimliğini alın(videoFileName olarak kabul edelim)
            string folderFileName = foldercontent.FolderPath; // Örneğin sabit bir isimle saklamış olalım

            // Videonun yüklendiği klasör yolunu belirleyin
            string FolderPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Folder");

            // Fiziksel dosya yolunu oluşturun
            string folderFilePath = Path.Combine(FolderPath, folderFileName);

            // Dosyayı diskten silin
            if (System.IO.File.Exists(folderFilePath))
            {
                System.IO.File.Delete(folderFilePath);
            }

            var result = _folderService.Delete(foldercontent);
            if (result.Success == true)
            {
                TempData.Add("message", "Başarıyla Silindi");

            }
            else
            {
                TempData.Add("errormessage", result.Message);
            }

            return Redirect("/CustomerProfile/Index/" + customerId);
        }

    }
}
