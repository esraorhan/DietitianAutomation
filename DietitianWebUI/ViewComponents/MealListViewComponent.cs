using Business.Abstract;
using DietitianWebUI.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
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
            var mealList = _mealService.GetList().Data;
            var model = new MealViewModel
            {
                Meals = mealList
            };
            return View(model);
        }
    }
}
