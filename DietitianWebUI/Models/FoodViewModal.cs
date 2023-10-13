using Entities.Concrete;
using Entities.Dtos;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DietitianWebUI.Models
{
    public class FoodViewModal
    {
        public Food Food { get; set; }
        public List<FoodListByCategoryDto> Foods { get; set; }
        public IEnumerable<SelectListItem> Categories { get; set; }
    }
}
