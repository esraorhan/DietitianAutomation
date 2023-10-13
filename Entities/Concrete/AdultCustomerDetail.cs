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
        public string CustomerTarget { get; set; } //müşteri hedefi 
        public string Allergy { get; set; }
        public string GeneticDisease { get; set; }
        public bool AlcoholUse { get; set; }
        public string Description { get; set; }
        public decimal BMH_value { get; set; }
        public decimal PAL_value { get; set; }
    }
}
