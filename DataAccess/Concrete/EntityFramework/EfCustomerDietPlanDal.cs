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
    public class EfCustomerDietPlanDal : EfEntityRepositoryBase<CustomerDietPlan, DietContext>, ICustomerDietPlanDal
    {
        public List<CustomerDietPlansListByMealGroupDto> GetCustomerDietPlanListByMealGroupDto(int CustomerDietListId)
        {
            using (var context = new DietContext())
            {

                var intermediateResult = (from dp in context.CustomerDietPlans
                                          join f in context.Foods on dp.FoodID equals f.FoodID
                                          join m in context.Meals on dp.MealID equals m.MealID
                                          where dp.CustomerDietListId == CustomerDietListId
                                          select new
                                          {
                                              dp,
                                              f,
                                              m
                                          }).ToList();

               

                var result = (from g in intermediateResult
                              group g by new { g.m.MealID, g.m.MealName, g.m.MealTime } into grouped
                              select new CustomerDietPlansListByMealGroupDto
                              {
                                  MealID = grouped.Key.MealID,
                                  MealName = grouped.Key.MealName,
                                  MealTime = grouped.Key.MealTime,

                                  SumCalorie = grouped.Sum(c => c.dp.Calorie),
                                  CustomerDietPlandtosGrouped = grouped
                                                        .GroupBy(subGroup => subGroup.dp.HowManyDays)  // İkinci gruplama işlemi
                                                        .Select(subGroup => new CustomerDietPlandtosGroupedDto
                                                        {
                                                            HowManyDaysGroup = subGroup.Key,
                                                            CustomerDietPlanDtos = subGroup.Select(g => new CustomerDietPlanDto
                                                            {
                                                                CustomerDietListId = g.dp.CustomerDietListId,
                                                                Amount = g.dp.Amount,
                                                                Calorie = g.dp.Calorie,
                                                                Carbohydrate = g.dp.Carbohydrate,
                                                                Description = g.dp.Description,
                                                                CustomerDietPlanId = g.dp.CustomerDietPlanId,
                                                                FoodID = g.dp.FoodID,
                                                                FoodName = g.f.FoodName,
                                                                Oil = g.dp.Oil,
                                                                Protein = g.dp.Protein,
                                                                UnitOfMeasure = g.f.UnitOfMeasure
                                                            }).ToList()
                                                        }).ToList()
                              }).ToList();






                return result;
            }
        }
    }
}
