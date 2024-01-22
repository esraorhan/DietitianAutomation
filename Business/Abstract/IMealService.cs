using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IMealService
    {
        IDataResult<List<Meal>> GetList(int UserId);
        IDataResult<Meal> GetById(int mealId);
        IResult Update(Meal meal);
        IResult Add(Meal meal);
    }
}
