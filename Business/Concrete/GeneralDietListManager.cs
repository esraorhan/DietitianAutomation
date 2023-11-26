using Business.Abstract;
using Business.Contans;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class GeneralDietListManager : IGeneralDietListService
    {
        private IGeneralDietListDal _generalDietListDal;

        public GeneralDietListManager(IGeneralDietListDal generalDietListDal)
        {
            _generalDietListDal = generalDietListDal;
        }

        public IResult Add(GeneralDietList dietList)
        {
            var result = _generalDietListDal.GET(d => d.DietName == dietList.DietName);
            if (result == null)
            {
                _generalDietListDal.ADD(dietList);
                return new SuccessResult(Messages.Added);
            }
            else
            {
                return new ErrorDataResult<Category>(Messages.RepeatRecording);
            }
        }

        public IResult Delete(GeneralDietList dietList)
        {
            _generalDietListDal.DELETE(dietList);
            return new SuccessResult(Messages.Deleted);
        }

        public IDataResult<GeneralDietList> GetById(int DietItemId)
        {
            return new SuccessDataResult<GeneralDietList>(_generalDietListDal.GET(c => c.DietItemId == DietItemId));
        }

        public IDataResult<List<GeneralDietList>> GetList(int? customerId)
        {
            return new SuccessDataResult<List<GeneralDietList>>(_generalDietListDal.GETLIST(c => c.AdultCustomerID == customerId).ToList());
        }

        public IDataResult<List<GeneralDietList>> GetList()
        {
            return new SuccessDataResult<List<GeneralDietList>>(_generalDietListDal.GETLIST().ToList());
        }

        public IResult Update(GeneralDietList dietList)
        {
            _generalDietListDal.UPDATE(dietList);
            return new SuccessResult(Messages.Updated);
        }
    }
}
