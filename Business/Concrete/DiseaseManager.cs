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
    public class DiseaseManager : IDiseaseService
    {
        private IDiseaseDal _diseaseDal;

        public DiseaseManager(IDiseaseDal diseaseDal)
        {
            _diseaseDal = diseaseDal;
        }

        public IResult Add(Disease disease)
        {
            var result = _diseaseDal.GET(d => d.DiseaseName == disease.DiseaseName);
            if (result == null)
            {
                _diseaseDal.ADD(disease);
                return new SuccessResult(Messages.Added);
            }
            else
            {
                return new ErrorDataResult<Category>(Messages.RepeatRecording);
            }
        }

        public IResult Delete(Disease disease)
        {
            _diseaseDal.DELETE(disease);
            return new SuccessResult(Messages.Deleted);
        }

        public IDataResult<Disease> GetById(int diseaseId)
        {
            return new SuccessDataResult<Disease>(_diseaseDal.GET(c => c.DiseaseId == diseaseId));
        }

        public IDataResult<List<Disease>> GetList()
        {
            return new SuccessDataResult<List<Disease>>(_diseaseDal.GETLIST().ToList());
        }

        public IDataResult<List<DiseaseDto>> GetListDiseasesByCustomers(int CustomerId)
        {
            return new SuccessDataResult<List<DiseaseDto>>(_diseaseDal.GetListDiseases(CustomerId));
        }

        public IResult Update(Disease disease)
        {
            _diseaseDal.UPDATE(disease);
            return new SuccessResult(Messages.Updated);
        }
    }
}
