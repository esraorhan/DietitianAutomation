using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class CustomerFolder : IEntity
    {
        public int CustomerFolderId { get; set; }
        public int AdultCustomerID { get; set; }
        public string FolderTitle { get; set; }
        public string FolderDescription { get; set; }
        public string FolderPath { get; set; }
        public DateTime CreationDate { get; set; }

    }
}
