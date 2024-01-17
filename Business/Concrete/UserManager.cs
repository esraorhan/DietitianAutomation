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
    public class UserManager : IUserService
    {
        private IUserDal _userDal;

        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }

        public IResult Add(User user)
        {
            var result = _userDal.GET(d => d.FullName == user.FullName);
            if (result == null)
            {
                _userDal.ADD(user);
                return new SuccessResult(Messages.Added);
            }
            else
            {
                return new ErrorDataResult<Category>(Messages.RepeatRecording);
            }
        }

        public IResult Delete(User user)
        {
            _userDal.DELETE(user);
            return new SuccessResult(Messages.Deleted);
        }

        public IDataResult<User> GetById(int userId)
        {
            return new SuccessDataResult<User>(_userDal.GET(c=>c.UserID==userId));
        }

        public IDataResult<List<UserListByRoleDto>> GetUserList()
        {
            return new SuccessDataResult<List<UserListByRoleDto>>(_userDal.GetUserListByRole().ToList());
        }

        public IResult Update(User user)
        {
            _userDal.UPDATE(user);
            return new SuccessResult(Messages.Updated);
        }
    }
}
