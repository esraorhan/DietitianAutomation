using Business.Abstract;
using Business.Contans;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class MealManager : IMealService
    {
        private IMealDal _mealDal;

        public MealManager(IMealDal mealDal)
        {
            _mealDal = mealDal;
        }

        public IResult Add(Meal meal)
        {
            var result = _mealDal.GET(d => d.MealName == meal.MealName);
            if (result == null)
            {
                _mealDal.ADD(meal);
                return new SuccessResult(Messages.Added);
            }
            else
            {
                return new ErrorDataResult<Category>(Messages.RepeatRecording);
            }
        }

        public IDataResult<Meal> GetById(int mealId)
        {
            return new SuccessDataResult<Meal>(_mealDal.GET(m => m.MealID == mealId));
        }

        public IDataResult<List<Meal>> GetList(int UserId)
        {
            return new SuccessDataResult<List<Meal>>(_mealDal.GETLIST(c=>c.UserId==UserId).ToList());
        }

        public IResult Update(Meal meal)
        {
            _mealDal.UPDATE(meal);
            return new SuccessResult(Messages.Updated);
        }
    }
}
