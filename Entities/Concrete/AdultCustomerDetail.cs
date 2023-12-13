using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
   public class AdultCustomerDetail:IEntity
    {
        public int AdultCustomerDetailID { get; set; }
        public int AdultCustomerID { get; set; } // danısanid
      
      
        public decimal? BMH_value { get; set; }
        public decimal? PAL_value { get; set; }
        public decimal? Vki_value { get; set; }
        public decimal? BodyFatIndex { get; set; }
        public string Vki_comment { get; set; }
        public decimal? MinProtectionOfWeightCalorie { get; set; }
        public decimal? MaxProtectionOfWeightCalorie { get; set; }
    }
}
