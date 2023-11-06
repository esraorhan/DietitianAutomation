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
    public interface IAdultCustomerDetailService
    {
       // IDataResult<List<AdultCustomerDetail>> GetList(int adultCustomerId);
        IDataResult<AdultCustomerDetailListByCustomerDto> GetDetailCustomer(int adultCustomerId);
        IResult Update(AdultCustomerDetail  customerDetail);
        IResult Add(AdultCustomerDetail customerDetail);
        IResult Delete(AdultCustomerDetail customerDetail);
    }
}
