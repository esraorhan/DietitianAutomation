using Business.Abstract;
using Business.Contans;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class FoodManager : IFoodService
    {
       private IFoodDal _foodDal;

        public FoodManager(IFoodDal foodDal)
        {
            _foodDal = foodDal;
        }

        public IResult Add(Food food)
        {
            var result = _foodDal.GET(d => d.FoodName == food.FoodName);
            if (result == null)
            {
                _foodDal.ADD(food);
                return new SuccessResult(Messages.Added);
            }
            else
            {
                return new ErrorDataResult<Category>(Messages.RepeatRecording);
            }
        }

        public IResult Delete(Food food)
        {
            _foodDal.DELETE(food);
            return new SuccessResult(Messages.Deleted);
        }

        public IDataResult<Food> GetById(int foodId)
        {
            return new SuccessDataResult<Food>(_foodDal.GET(m => m.FoodID == foodId));
        }

        public IDataResult<List<FoodListByCategoryDto>> GetFoodListByCategories()
        {
            return new SuccessDataResult<List<FoodListByCategoryDto>>(_foodDal.GetFoodListByCategories());
        }

        public IResult Update(Food food)
        {
            _foodDal.UPDATE(food);
            return new SuccessResult(Messages.Updated);
        }
    }
}
