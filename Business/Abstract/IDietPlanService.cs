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
    public interface IDietPlanService
    {
        IDataResult<List<DietPlan>> GetList(int dietItemId);

        IDataResult<List<DietPlansListByMealGroupDto>> GetDietPlanListByMealGroupDto(int dietItemId);
        IDataResult<DietPlan> GetById(int DietPlanId);
        IResult Update(DietPlan dietPlan);
        IResult Add(DietPlan dietPlan);
        IResult Delete(DietPlan dietPlan);
    }
}
