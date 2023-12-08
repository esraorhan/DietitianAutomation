using Entities.Dtos;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace DietitianWebUI.Models
{
    public class CustomerProfileViewModel
    {
        public AdultCustomerDetailListByCustomerDto  AdultCustomerDetail { get; set; }
        public AdultMeeting AdultMeeting { get; set; }
        public List<AdultMeeting> AdultMeetings { get; set; }
        public CustomerFolder CustomerFolder { get; set; }
        public List<CustomerFolder> CustomerFolders { get; set; }
        public List<DiseaseDto> Diseases { get; set; }

        public CustomerDietList CustomerDietList { get; set; }
        public List<CustomerDietList> CustomerDietLists { get; set; }
        public IEnumerable<SelectListItem> GenerelDietSablons { get; set; }
    }
}
