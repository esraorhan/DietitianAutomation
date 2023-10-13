using Business.Abstract;
using Business.Contans;
using Core.Utilities.Results;
using Entities.Concrete;
using DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CategoryManager : ICategoryService
    {
        private ICategoryDal _categoryDal;

        public CategoryManager(ICategoryDal categoryDal)
        {
            _categoryDal = categoryDal;
        }

        public IResult Add(Category category)
        {
            var result = _categoryDal.GET(d => d.CategoryName == category.CategoryName);
            if (result == null)
            {
                _categoryDal.ADD(category);
                return new SuccessResult(Messages.Added);
            }
            else
            {
                return new ErrorDataResult<Category>(Messages.RepeatRecording);
            }
        }

        public IResult Delete(Category category)
        {
            _categoryDal.DELETE(category);
            return new SuccessResult(Messages.Deleted);
        }

        public IDataResult<Category> GetById(int categoryId)
        {
            return new SuccessDataResult<Category>(_categoryDal.GET(c => c.CategoryID == categoryId));
        }

        public IDataResult<List<Category>> GetList()
        {
            return new SuccessDataResult<List<Category>>(_categoryDal.GETLIST().ToList());
        }

        public IResult Update(Category category)
        {
            _categoryDal.UPDATE(category);
            return new SuccessResult(Messages.Updated);
        }
    }
}
