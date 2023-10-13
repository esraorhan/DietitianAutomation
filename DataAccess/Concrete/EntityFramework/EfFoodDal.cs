using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework.Context;
using Entities.Concrete;
using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfFoodDal : EfEntityRepositoryBase<Food, DietContext>, IFoodDal
    {
        public List<FoodListByCategoryDto> GetFoodListByCategories()
        {
            using (var context = new DietContext())
            {
                var result = (from f in context.Foods
                              join c in context.Categories on f.CategoryID equals c.CategoryID
                              select new FoodListByCategoryDto
                              {
                                  FoodID = f.FoodID,
                                  FoodName = f.FoodName,
                                  CategoryID = f.CategoryID,
                                  Amount = f.Amount,
                                  Calorie = f.Calorie,
                                  Carbohydrate = f.Carbohydrate,
                                  Oil = f.Oil,
                                  UnitOfMeasure = f.UnitOfMeasure,
                                  CategoryName = c.CategoryName,
                                  Description = c.Description,
                                 Protein =f.Protein
                              });

                return result.ToList();
            }
        }
    }
}
