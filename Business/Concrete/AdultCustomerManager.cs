using Business.Abstract;
using Business.Contans;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class AdultCustomerManager : IAdultCustomerService
    {
        private IAdultCustomerDal _customerDal;
        private IAdultCustomerDetailDal _customerDetailDal;

        public AdultCustomerManager(IAdultCustomerDal customerDal, IAdultCustomerDetailDal customerDetailDal)
        {
            _customerDal = customerDal;
            _customerDetailDal = customerDetailDal;
        }

        public IResult Add(AdultCustomer adultCustomer)
        {
            var result = _customerDal.GET(d => d.FullName == adultCustomer.FullName);
            if (result == null)
            {
                _customerDal.ADD(adultCustomer);
              
                return new SuccessResult(Messages.Added);
            }
            else
            {
                return new ErrorDataResult<Category>(Messages.RepeatRecording);
            }
        }

        public IResult Delete(AdultCustomer adultCustomer)
        {
            _customerDal.DELETE(adultCustomer);
            return new SuccessResult(Messages.Deleted);
        }

        public IDataResult<AdultCustomer> GetById(int adultCustomerId)
        {
            return new SuccessDataResult<AdultCustomer>(_customerDal.GET(c => c.AdultCustomerID == adultCustomerId));
        }

        public IDataResult<List<AdultCustomer>> GetList()
        {
            return new SuccessDataResult<List<AdultCustomer>>(_customerDal.GETLIST().ToList());
        }

        public IResult Update(AdultCustomer adultCustomer)
        {
            _customerDal.UPDATE(adultCustomer);
            return new SuccessResult(Messages.Updated);
        }
    }
}
