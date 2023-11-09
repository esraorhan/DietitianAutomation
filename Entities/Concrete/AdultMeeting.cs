using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class AdultMeeting :IEntity
    {
        public int AdultMeetingID { get; set; }
        public int AdultCustomerID { get; set; }
        public decimal UpdateKilo { get; set; }
        public int WaistSize { get; set; }
        public int HaunchSize { get; set; }
        public int HipSize { get; set; }
        public int ChestSize { get; set; }
        public int ArmSize { get; set; }
        public int StomachSize { get; set; }
        public int FatRate { get; set; }
        public string Description { get; set; }
        public DateTime MeetingDate { get; set; }
    }
}
