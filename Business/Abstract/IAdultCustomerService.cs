using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IAdultCustomerService
    {
        IDataResult<List<AdultCustomer>> GetList();
        IDataResult<AdultCustomer> GetById(int adultCustomerId);
        IResult Update(AdultCustomer adultCustomer);
        IResult Add(AdultCustomer adultCustomer);
        IResult Delete(AdultCustomer adultCustomer);
    }
}
