using Business.Abstract;
using Business.ValidationRules;
using DietitianWebUI.Models;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace DietitianWebUI.Controllers
{
    [Authorize(Roles = "Admin")]
    public class UserController : Controller
    {
        private IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        public IActionResult Index()
        {
            var userlist = _userService.GetUserList().Data;
            var model = new UserViewModel
            {
                Users = userlist
            };
            return View(model);
        }
        [HttpPost("/User/Add/")]
        public IActionResult Add(UserViewModel model)
        {
            var file = Request.Form.Files["formFile"];
            UserValidator uv = new UserValidator();
            ValidationResult result = uv.Validate(model.User);
            try
            {
                if (result.IsValid) 
                {
                    if (file.ContentType == "image/png" || file.ContentType == "image/jpeg" || file.ContentType == "application/pdf")
                    {
                        var extension = Path.GetExtension(file.FileName);
                        var userProfilefile = Path.GetFileNameWithoutExtension(file.FileName.Replace(' ', '_')) + extension;
                        var location = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Folder/UserProfile/", userProfilefile);
                        using (var stream = new FileStream(location, FileMode.Create))
                        {
                            file.CopyTo(stream);
                        }
                        model.User.UserProfileFolder = userProfilefile;
                        model.User.CreationDate = DateTime.Now;
                        model.User.Status = true;
                        var folder = _userService.Add(model.User);
                        if (folder.Success == true)
                        {
                            TempData.Add("message", folder.Message);
                        }
                        else
                        {
                            TempData.Add("errormessage", folder.Message);
                        }
                    }
                    else
                    {
                        TempData.Add("errormessage", "Lütfen geçerli formatta yükleyin");
                    }
                   
                }
                else
                {
                    foreach (var item in result.Errors)
                    {

                        ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                    }
                    return View("Index", model);
                   
                }
            }
            catch (Exception ex)
            {

                TempData.Add("errormessage", ex.Message);
              
            }
            return Redirect("Index");
            //return Redirect("Index");
        }
        [HttpGet("/User/Edit/{UserId}")]
        public IActionResult Edit(int UserId)
        {
            var user = _userService.GetById(UserId).Data;
            var model = new UserViewModel
            {
                User = user
            };
            return PartialView("EditUserViewModal",model);
        }
        [HttpPost]
        public IActionResult Edit(UserViewModel model)
        {
            var file = Request.Form.Files["formFileEdit"];
            if (file!=null)
            {
                if (file.ContentType == "image/png" || file.ContentType == "image/jpeg" || file.ContentType == "application/pdf")
                {

                    var extension = Path.GetExtension(file.FileName);
                    var userProfilefile = Path.GetFileNameWithoutExtension(file.FileName.Replace(' ', '_')) + extension;
                    var location = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Folder/UserProfile/", userProfilefile);
                    using (var stream = new FileStream(location, FileMode.Create))
                    {
                        file.CopyTo(stream);
                    }
                    model.User.UserProfileFolder = userProfilefile;
                    var result = _userService.Update(model.User);
                    if (result.Success == true)
                    {
                        TempData.Add("message", result.Message);

                    }
                    else
                    {
                        TempData.Add("errormessage", result.Message);
                    }
                }
                else
                {
                    TempData.Add("errormessage", "Lütfen geçerli formatta yükleyin");
                }
            }
            else
            {
                var result = _userService.Update(model.User);
                if (result.Success == true)
                {
                    TempData.Add("message", result.Message);

                }
                else
                {
                    TempData.Add("errormessage", result.Message);
                }
            }
            
           
            return Redirect("/User/Index");
        }

        public IActionResult Delete(int UserId)
        {
            var user = _userService.GetById(UserId).Data;
            user.Status = false;
            var result = _userService.Update(user);
            if (result.Success == true)
            {
                TempData.Add("message", result.Message);

            }
            else
            {
                TempData.Add("errormessage", result.Message);
            }
            return Redirect("/User/Index");
        }
    }
}
