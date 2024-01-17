using Entities.Concrete;
using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DietitianWebUI.Models
{
    public class UserViewModel
    {
        public User User { get; set; }
        public List<UserListByRoleDto> Users { get; set; }
    }
}
