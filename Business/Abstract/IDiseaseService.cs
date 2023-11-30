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
    public interface IDiseaseService
    {
        IDataResult<List<Disease>> GetList();
        IDataResult<List<DiseaseDto>> GetListDiseasesByCustomers(int CustomerId);
        IDataResult<Disease> GetById(int diseaseId);
        IResult Update(Disease disease);
        IResult Add(Disease disease);
        IResult Delete(Disease disease);
    }
}
