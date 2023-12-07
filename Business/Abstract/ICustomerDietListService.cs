using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ICustomerDietListService
    {
        IDataResult<List<CustomerDietList>> GetList(int? customerId);
        IDataResult<CustomerDietList> GetById(int CustomerDietListId);
        IResult Update(CustomerDietList dietList);
        IResult Add(CustomerDietList dietList);
        IResult Delete(CustomerDietList dietList);
    }
}
