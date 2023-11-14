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
    public class EfDietPlanDal : EfEntityRepositoryBase<DietPlan, DietContext>, IDietPlanDal
    {
        public List<DietPlansListByMealGroupDto> GetDietPlanListByMealGroupDto(int DietItemId)
        {
            using (var context = new DietContext())
            {

                var intermediateResult = (from dp in context.DietPlans
                                          join f in context.Foods on dp.FoodID equals f.FoodID
                                          join m in context.Meals on dp.MealID equals m.MealID
                                          where dp.DietItemId == DietItemId
                                          select new
                                          {
                                              dp,
                                              f,
                                              m
                                          }).ToList();

                var result = (from g in intermediateResult
                              group g by new { g.m.MealID, g.m.MealName,g.m.MealTime } into grouped
                              select new DietPlansListByMealGroupDto
                              {
                                  MealID = grouped.Key.MealID,
                                  MealName = grouped.Key.MealName,
                                  MealTime = grouped.Key.MealTime,
                                 SumCalorie =grouped.Sum(c=>c.dp.Calorie),
                                  DietPlandtos = grouped.Select(g => new DietPlandto
                                  {
                                      DietItemId = g.dp.DietItemId,
                                      Amount = g.dp.Amount,
                                      Calorie = g.dp.Calorie,
                                      Carbohydrate = g.dp.Carbohydrate,
                                      Description = g.dp.Description,
                                      DietPlanId = g.dp.DietPlanId,
                                      FoodID = g.dp.FoodID,
                                      FoodName = g.f.FoodName,
                                     
                                      Oil = g.dp.Oil,
                                      Protein = g.dp.Protein,
                                      UnitOfMeasure = g.f.UnitOfMeasure
                                  }).ToList()
                              }).ToList();
              





                              //  var result = (from dp in context.DietPlans
                              //join f in context.Foods on dp.FoodID equals f.FoodID
                              //join m in context.Meals on dp.MealID equals m.MealID
                              //where dp.DietItemId==DietItemId
                              //group new { dp, f, m } by new { m.MealID, m.MealName } into grouped
                              //select new DietPlansListByMealGroupDto
                              //{
                              //    MealID = grouped.Key.MealID,
                              //    MealName = grouped.Key.MealName,
                              //    DietPlandtos = grouped.Select(g => new DietPlandto
                              //    {
                              //        DietItemId =g.dp.DietItemId,
                              //        Amount =g.dp.Amount,
                              //        Calorie =g.dp.Calorie,
                              //        Carbohydrate =g.dp.Carbohydrate,
                              //        Description =g.dp.Description,
                              //        DietPlanId =g.dp.DietPlanId,
                              //        FoodID =g.dp.FoodID,
                              //        FoodName =g.f.FoodName,
                              //        MealTime =g.m.MealTime,
                              //        Oil =g.dp.Oil,
                              //        Protein =g.dp.Protein,
                              //        UnitOfMeasure =g.f.UnitOfMeasure
                              //    }).ToList()
                              //}).ToList();

                return result;
            }
        }
    }
}
