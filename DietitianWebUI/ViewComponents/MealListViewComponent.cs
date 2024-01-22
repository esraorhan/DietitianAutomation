using Business.Abstract;
using DietitianWebUI.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace DietitianWebUI.ViewComponents
{
    public class MealListViewComponent : ViewComponent
    {
        private IMealService _mealService;

        public MealListViewComponent(IMealService mealService)
        {
            _mealService = mealService;
        }
        public IViewComponentResult Invoke()
        {
          var userId =  Convert.ToInt32(HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier));
            var mealList = _mealService.GetList(userId).Data;
            var model = new MealViewModel
            {
                Meals = mealList
            };
            return View(model);
        }
    }
}
