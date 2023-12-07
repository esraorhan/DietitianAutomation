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
    public class CustomerDietPlanManager : ICustomerDietPlanService
    {
        ICustomerDietPlanDal _customerDietPlanDal;

        public CustomerDietPlanManager(ICustomerDietPlanDal customerDietPlanDal)
        {
            _customerDietPlanDal = customerDietPlanDal;
        }

        public IResult Add(CustomerDietPlan dietPlan)
        {
            _customerDietPlanDal.ADD(dietPlan);
            return new SuccessResult(Messages.Added);
        }

        public IResult Delete(CustomerDietPlan dietPlan)
        {
            _customerDietPlanDal.DELETE(dietPlan);
            return new SuccessResult(Messages.Deleted);
        }

        public IDataResult<CustomerDietPlan> GetById(int customerDietPlanId)
        {
            return new SuccessDataResult<CustomerDietPlan>(_customerDietPlanDal.GET(c => c.CustomerDietPlanId == customerDietPlanId));
        }

        public IDataResult<List<CustomerDietPlansListByMealGroupDto>> GetCustomerDietPlanListByMealGroupDto(int CustomerDietListId)
        {
            return new SuccessDataResult<List<CustomerDietPlansListByMealGroupDto>>(_customerDietPlanDal.GetCustomerDietPlanListByMealGroupDto(CustomerDietListId));
        }

        public IDataResult<List<CustomerDietPlan>> GetList(int customerDietListId)
        {
            return new SuccessDataResult<List<CustomerDietPlan>>(_customerDietPlanDal.GETLIST(c => c.CustomerDietListId == customerDietListId).ToList());
        }

        public IResult Update(CustomerDietPlan dietPlan)
        {
            _customerDietPlanDal.UPDATE(dietPlan);
            return new SuccessResult(Messages.Updated);
        }
    }
}
