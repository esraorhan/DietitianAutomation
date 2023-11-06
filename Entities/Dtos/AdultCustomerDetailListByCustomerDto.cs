using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Dtos
{
    public class AdultCustomerDetailListByCustomerDto : IDto
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
        public int? Age { get; set; }
        public string CustomerTarget { get; set; } //müşteri hedefi 
        public string Allergy { get; set; }
        public string GeneticDisease { get; set; }
        public bool AlcoholUse { get; set; }
        public string Description { get; set; }

        public int AdultCustomerDetailID { get; set; }
        public decimal? BMH_value { get; set; }
        public decimal? PAL_value { get; set; }
        public decimal? Vki_value { get; set; }
        public decimal? BodyFatIndex { get; set; }
    }
}
