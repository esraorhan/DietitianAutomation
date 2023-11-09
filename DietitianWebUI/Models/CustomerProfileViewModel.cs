using Entities.Dtos;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DietitianWebUI.Models
{
    public class CustomerProfileViewModel
    {
        public AdultCustomerDetailListByCustomerDto  AdultCustomerDetail { get; set; }
        public AdultMeeting AdultMeeting { get; set; }
        public List<AdultMeeting> AdultMeetings { get; set; }
    }
}
