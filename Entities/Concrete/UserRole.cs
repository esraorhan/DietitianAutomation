using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class UserRole : IEntity
    {
        public int UserRoleID { get; set; }
        public string RoleName { get; set; }
    }
}
