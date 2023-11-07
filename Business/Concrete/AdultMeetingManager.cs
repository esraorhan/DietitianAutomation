using Business.Abstract;
using Business.Contans;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class AdultMeetingManager : IAdultMeetingService
    {
        private IAdultMeetingDal _meetingDal;

        public AdultMeetingManager(IAdultMeetingDal meetingDal)
        {
            _meetingDal = meetingDal;
        }

        public IResult Add(AdultMeeting meeting)
        {
            _meetingDal.ADD(meeting);
            return new SuccessResult(Messages.Added);
        }

        public IResult Delete(AdultMeeting meeting)
        {
            _meetingDal.DELETE(meeting);
            return new SuccessResult(Messages.Deleted);
        }

        public IDataResult<AdultMeeting> GetById(int meetingId)
        {
            return new SuccessDataResult<AdultMeeting>(_meetingDal.GET(c => c.AdultMeetingID == meetingId));
        }

        public IDataResult<List<AdultMeeting>> GetList()
        {
            return new SuccessDataResult<List<AdultMeeting>>(_meetingDal.GETLIST().ToList());
        }

        public IResult Update(AdultMeeting meeting)
        {
            _meetingDal.UPDATE(meeting);
            return new SuccessResult(Messages.Updated);
        }
    }
}
