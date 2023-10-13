using Business.Abstract;
using DietitianWebUI.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DietitianWebUI.ViewComponents
{
    public class FoodListViewComponent : ViewComponent
    {
        private IFoodService _foodService;

        public FoodListViewComponent(IFoodService foodService)
        {
            _foodService = foodService;
        }
        public IViewComponentResult Invoke()
        {
            var foodList = _foodService.GetFoodListByCategories().Data;
            var model = new FoodViewModal
            {
                Foods = foodList
            };
            return View(model);
        }
    }
}
