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
    public class DietPlanManager : IDietPlanService
    {
        IDietPlanDal _dietPlanDal;

        public DietPlanManager(IDietPlanDal dietPlanDal)
        {
            _dietPlanDal = dietPlanDal;
        }

        public IResult Add(DietPlan dietPlan)
        {
            _dietPlanDal.ADD(dietPlan);
            return new SuccessResult(Messages.Added);
        }

        public IResult Delete(DietPlan dietPlan)
        {
            _dietPlanDal.DELETE(dietPlan);
            return new SuccessResult(Messages.Deleted);
        }

        public IDataResult<DietPlan> GetById(int DietPlanId)
        {
            return new SuccessDataResult<DietPlan>(_dietPlanDal.GET(c => c.DietPlanId == DietPlanId));
        }

        public IDataResult<List<DietPlan>> GetList(int dietItemId)
        {
            return new SuccessDataResult<List<DietPlan>>(_dietPlanDal.GETLIST(c=>c.DietItemId==dietItemId).ToList());
        }

        public IResult Update(DietPlan dietPlan)
        {
            _dietPlanDal.UPDATE(dietPlan);
            return new SuccessResult(Messages.Updated);
        }
    }
}
