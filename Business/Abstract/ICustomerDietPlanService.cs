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
    public interface ICustomerDietPlanService
    {
        IDataResult<List<CustomerDietPlan>> GetList(int customerDietListId);

        IDataResult<List<CustomerDietPlansListByMealGroupDto>> GetCustomerDietPlanListByMealGroupDto(int customerDietListId);
        IDataResult<CustomerDietPlan> GetById(int CustomerDietPlanId);
        IResult Update(CustomerDietPlan dietPlan);
        IResult Add(CustomerDietPlan dietPlan);
        IResult Delete(CustomerDietPlan dietPlan);
    }
}
