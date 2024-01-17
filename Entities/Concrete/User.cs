using Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class User :IEntity
    {
        [Key]
        public int UserID { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string UserProfileFolder { get; set; }
        public int UserRoleID { get; set; }
        public string Password { get; set; }
        public DateTime CreationDate { get; set; }
        public bool Status { get; set; }

    }
}
