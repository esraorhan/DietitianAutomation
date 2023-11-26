using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IGeneralDietListService
    {
        IDataResult<List<GeneralDietList>> GetList(int? customerId);
        IDataResult<List<GeneralDietList>> GetList();
        IDataResult<GeneralDietList> GetById(int DietItemId);
        IResult Update(GeneralDietList dietList);
        IResult Add(GeneralDietList dietList);
        IResult Delete(GeneralDietList dietList);
    }
}
