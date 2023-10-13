using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class AdultCustomer: IEntity
    {
        public int AdultCustomerID { get; set; }
        public string FullName { get; set; }
        public string Mail { get; set; }
        public string Phone { get; set; }
        public string Gender { get; set; }
        public string Job { get; set; }
        public DateTime StartingDate { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string MannerOfWork { get; set; }
        public int Size { get; set; }
        public int Kilo { get; set; }
    }
}
