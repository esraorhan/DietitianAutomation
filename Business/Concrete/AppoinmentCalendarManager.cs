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
    public class AppoinmentCalendarManager : IAppoinmentCalendarService
    {
        private IAppoinmentCalendarDal _calendarDal;

        public AppoinmentCalendarManager(IAppoinmentCalendarDal calendarDal)
        {
            _calendarDal = calendarDal;
        }

        public IResult Add(AppoinmentCalendar calendar)
        {
            _calendarDal.ADD(calendar);
            return new SuccessResult(Messages.Added);
        }

        public IResult Delete(AppoinmentCalendar calendar)
        {
            _calendarDal.DELETE(calendar);
            return new SuccessResult(Messages.Deleted);
        }

        public IDataResult<AppoinmentCalendar> GetById(int appointmentID)
        {
            return new SuccessDataResult<AppoinmentCalendar>(_calendarDal.GET(m => m.AppointmentID == appointmentID));
        }

        public IDataResult<List<AppoinmentCalendar>> GetList(int userId)
        {
            return new SuccessDataResult<List<AppoinmentCalendar>>(_calendarDal.GETLIST(c=>c.UserId == userId).ToList());
        }

        public IResult Update(AppoinmentCalendar calendar)
        {
            _calendarDal.UPDATE(calendar);
            return new SuccessResult(Messages.Updated);
        }
    }
}
