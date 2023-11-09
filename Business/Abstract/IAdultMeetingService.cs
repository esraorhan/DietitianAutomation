using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
   public  interface IAdultMeetingService
    {
        IDataResult<List<AdultMeeting>> GetList(int customerId);
        IDataResult<AdultMeeting> GetById(int meetingId);
        IResult Update(AdultMeeting meeting);
        IResult Add(AdultMeeting meeting);
        IResult Delete(AdultMeeting meeting);
    }
}
