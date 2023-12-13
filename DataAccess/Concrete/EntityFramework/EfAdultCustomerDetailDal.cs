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
    public class EfAdultCustomerDetailDal : EfEntityRepositoryBase<AdultCustomerDetail, DietContext>, IAdultCustomerDetailDal
    {
        public AdultCustomerDetailListByCustomerDto GetDetailCustomer(int customerId)
        {
            using (var context = new DietContext())
            {
                var result = (from a in context.AdultCustomers
                              join d in context.AdultCustomerDetails on a.AdultCustomerID equals d.AdultCustomerDetailID
                              where a.AdultCustomerID ==customerId
                              select new AdultCustomerDetailListByCustomerDto
                              {
                                  AdultCustomerID = a.AdultCustomerID,
                                  Age = a.Age,
                                  AlcoholUse = a.AlcoholUse,
                                  Allergy = a.Allergy,
                                  CustomerTarget = a.CustomerTarget,
                                  DateOfBirth = a.DateOfBirth,
                                  Description = a.Description,
                                  FullName = a.FullName,
                                  Gender = a.Gender,
                                  GeneticDisease = a.GeneticDisease,
                                  Job = a.Job,
                                  Kilo = a.Kilo,
                                  Mail = a.Mail,
                                  MannerOfWork = a.MannerOfWork,
                                  Phone = a.Phone,
                                  Size = a.Size,
                                  StartingDate = a.StartingDate,
                                  AdultCustomerDetailID = d.AdultCustomerDetailID,
                                  BMH_value = d.BMH_value,
                                  BodyFatIndex = d.BodyFatIndex,
                                  PAL_value = d.PAL_value,
                                  Vki_value = d.Vki_value,
                                   Vki_comment=d.Vki_comment,
                                   MaxProtectionOfWeightCalorie=d.MaxProtectionOfWeightCalorie,
                                   MinProtectionOfWeightCalorie=d.MinProtectionOfWeightCalorie
                              });

                return result.FirstOrDefault();
            }
        }
    }
}
