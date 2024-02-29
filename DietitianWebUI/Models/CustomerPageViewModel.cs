using Entities.Concrete;
using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DietitianWebUI.Models
{
    public class CustomerPageViewModel
    {
        public AdultCustomerDetailListByCustomerDto AdultCustomerDetail { get; set; }
        public AdultMeeting AdultMeeting { get; set; }
        public List<DiseaseDto> Diseases { get; set; }
       
        public List<CustomerDietPlansListByMealGroupDto> CustomerDietPlansListByMeals { get; set; }
    }
}
