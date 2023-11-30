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
    public class EfDiseaseDal : EfEntityRepositoryBase<Disease, DietContext>, IDiseaseDal
    {
        public List<DiseaseDto> GetListDiseases(int CustomerId)
        {
            using (var context = new DietContext())
            {
                var diseaselist = context.AdultCustomers.Where(c => c.AdultCustomerID == CustomerId).AsEnumerable()
                                    .SelectMany(c => c.DiseaseId.Split('-'))
                                    .Select(d => Convert.ToInt32(d))
                                    .ToList();

                var result = context.Diseases
                                    .Where(d => diseaselist.Contains(d.DiseaseId))
                                    .Select(d => new DiseaseDto
                                    {
                                        DiseaseId = d.DiseaseId,
                                        Alcohol = d.Alcohol,
                                        Carbohydrate = d.Carbohydrate,
                                        Cholesterol = d.Cholesterol,
                                        DiseaseName = d.DiseaseName,
                                        Energy = d.Energy,
                                        Meal = d.Meal,
                                        Oil = d.Oil,
                                        Posa = d.Posa,
                                        Protein = d.Protein,
                                        Salt = d.Salt,
                                        VitaminMineral = d.VitaminMineral,
                                        Water = d.Water
                                    })
                                    .ToList();

                return result.ToList();
            }
        }
    }
}
