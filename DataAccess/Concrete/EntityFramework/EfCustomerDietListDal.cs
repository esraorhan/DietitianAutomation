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
    public class EfCustomerDietListDal : EfEntityRepositoryBase<CustomerDietList, DietContext>, ICustomerDietListDal
    {
        public CustomerDietListByCustomerDto GetCustomerDietListDescFirst(int customerId)
        {
            using (var context = new DietContext())
            {
                var result = (from c in context.CustomerDietLists
                              where c.AdultCustomerID == customerId
                              orderby c.Date descending
                              select new CustomerDietListByCustomerDto
                              {
                                  AdultCustomerID =c.AdultCustomerID,
                                  CustomerDietListId=c.CustomerDietListId,
                                  Date=c.Date,
                                  Description=c.Description,
                                  DietItemId=c.DietItemId,
                                  DietName=c.DietName,
                                  TotalCalories=c.TotalCalories
                              });

                return result.FirstOrDefault();
            }
        }
    }
}
