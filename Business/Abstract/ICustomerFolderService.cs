using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ICustomerFolderService
    {
        IDataResult<List<CustomerFolder>> GetList(int customerId);
        IDataResult<CustomerFolder> GetById(int folderId);
        IResult Update(CustomerFolder folder);
        IResult Add(CustomerFolder folder);
        IResult Delete(CustomerFolder folder);
    }
}
