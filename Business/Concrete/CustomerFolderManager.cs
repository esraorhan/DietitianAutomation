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
    public class CustomerFolderManager : ICustomerFolderService
    {
        private ICustomerFolderDal _folderDal;

        public CustomerFolderManager(ICustomerFolderDal folderDal)
        {
            _folderDal = folderDal;
        }

        public IResult Add(CustomerFolder folder)
        {
            var result = _folderDal.GET(d => d.FolderPath == folder.FolderPath);
            if (result == null)
            {
                _folderDal.ADD(folder);

                return new SuccessResult(Messages.Added);
            }
            else
            {
                return new ErrorDataResult<Category>(Messages.RepeatRecording+"aynı yol verilmiş");
            }
        }

        public IResult Delete(CustomerFolder folder)
        {
            _folderDal.DELETE(folder);
            return new SuccessResult(Messages.Deleted);
        }

        public IDataResult<CustomerFolder> GetById(int folderId)
        {
            return new SuccessDataResult<CustomerFolder>(_folderDal.GET(c => c.CustomerFolderId == folderId));
        }

        public IDataResult<List<CustomerFolder>> GetList(int customerId)
        {
            return new SuccessDataResult<List<CustomerFolder>>(_folderDal.GETLIST(c => c.AdultCustomerID == customerId));
        }

        public IResult Update(CustomerFolder folder)
        {
            _folderDal.UPDATE(folder);
            return new SuccessResult(Messages.Updated);
        }
    }
}
