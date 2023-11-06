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
    public class AdultCustomerDetailManager : IAdultCustomerDetailService
    {
        IAdultCustomerDetailDal _customerDetailDal;

        public AdultCustomerDetailManager(IAdultCustomerDetailDal customerDetailDal)
        {
            _customerDetailDal = customerDetailDal;
        }

        public IResult Add(AdultCustomerDetail customerDetail)
        {
            var result = _customerDetailDal.GET(d => d.AdultCustomerID == customerDetail.AdultCustomerID);
            if (result == null)
            {
                _customerDetailDal.ADD(customerDetail);
                
                return new SuccessResult(Messages.Added);
            }
            else
            {
                return new ErrorDataResult<Category>(Messages.RepeatRecording);
            }
        }

        public IResult Delete(AdultCustomerDetail customerDetail)
        {
            _customerDetailDal.DELETE(customerDetail);
            return new SuccessResult(Messages.Deleted);
        }

        public IDataResult<AdultCustomerDetailListByCustomerDto> GetDetailCustomer(int adultCustomerId)
        {
            return new SuccessDataResult<AdultCustomerDetailListByCustomerDto>(_customerDetailDal.GetDetailCustomer(adultCustomerId));
        }

        public IResult Update(AdultCustomerDetail customerDetail)
        {
            _customerDetailDal.UPDATE(customerDetail);
            return new SuccessResult(Messages.Updated);
        }
    }
}
