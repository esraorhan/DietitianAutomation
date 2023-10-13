using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Dtos
{
    public class FoodListByCategoryDto :IDto
    {
        public int FoodID { get; set; }
        public string FoodName { get; set; }
        public decimal Amount { get; set; }
        public string UnitOfMeasure { get; set; }
        public decimal? Calorie { get; set; }
        public decimal? Carbohydrate { get; set; }
        public decimal? Oil { get; set; }
        public decimal? Protein { get; set; }
        public int CategoryID { get; set; }
        public string CategoryName { get; set; }
        public string Description { get; set; }
    }
}
