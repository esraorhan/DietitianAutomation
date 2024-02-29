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
    public class CustomerDietListManager : ICustomerDietListService
    {
        private ICustomerDietListDal _customerDietListDal;

        public CustomerDietListManager(ICustomerDietListDal customerDietListDal)
        {
            _customerDietListDal = customerDietListDal;
        }

        public IResult Add(CustomerDietList dietList)
        {
            var result = _customerDietListDal.GET(d => d.DietName == dietList.DietName);
            if (result == null)
            {
                _customerDietListDal.ADD(dietList);
                return new SuccessResult(Messages.Added);
            }
            else
            {
                return new ErrorDataResult<Category>(Messages.RepeatRecording);
            }
        }

        public IResult Delete(CustomerDietList dietList)
        {
            _customerDietListDal.DELETE(dietList);
            return new SuccessResult(Messages.Deleted);
        }

        public IDataResult<CustomerDietList> GetById(int CustomerDietListId)
        {
            return new SuccessDataResult<CustomerDietList>(_customerDietListDal.GET(c => c.CustomerDietListId == CustomerDietListId));
        }

        public IDataResult<CustomerDietListByCustomerDto> GetCustomerDietListDescFirst(int customerId)
        {
            return new SuccessDataResult<CustomerDietListByCustomerDto>(_customerDietListDal.GetCustomerDietListDescFirst(customerId));
        }

        public IDataResult<List<CustomerDietList>> GetList(int? customerId)
        {
            return new SuccessDataResult<List<CustomerDietList>>(_customerDietListDal.GETLIST(c => c.AdultCustomerID == customerId).ToList());
        }

        public IResult Update(CustomerDietList dietList)
        {
            _customerDietListDal.UPDATE(dietList);
            return new SuccessResult(Messages.Updated);
        }
    }
}
