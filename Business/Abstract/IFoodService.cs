using Core.Utilities.Results;
using Entities.Concrete;
using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IFoodService
    {
        IDataResult<List<FoodListByCategoryDto>> GetFoodListByCategories();
        IDataResult<Food> GetById(int foodId);
        IResult Update(Food food);
        IResult Add(Food food);
        IResult Delete(Food food);
    }
}
