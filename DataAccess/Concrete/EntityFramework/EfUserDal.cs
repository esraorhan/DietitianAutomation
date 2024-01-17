using Core.DataAccess;
using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework.Context;
using Entities.Concrete;
using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfUserDal : EfEntityRepositoryBase<User, DietContext>, IUserDal
    {
        public List<UserListByRoleDto> GetUserListByRole()
        {
            using (var context = new DietContext())
            {
                var result = (from u in context.Users
                              join r in context.UserRoles on u.UserRoleID equals r.UserRoleID
                              where u.Status == true
                              select new UserListByRoleDto
                              {
                                  FullName = u.FullName,
                                  UserRoleID = u.UserRoleID,
                                  Email = u.Email,
                                  Password = u.Password,
                                  Phone = u.Phone,
                                  RoleName = r.RoleName,
                                  UserID = u.UserID,
                                  CreationDate = u.CreationDate,
                                  Status = u.Status,
                                  UserProfileFolder=u.UserProfileFolder
                              }).ToList();
                return result;
            }

        }
    }
}
