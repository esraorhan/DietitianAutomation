using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IAppoinmentCalendarService
    {
        IDataResult<List<AppoinmentCalendar>> GetList(int userId);
        IDataResult<AppoinmentCalendar> GetById(int appointmentID);
        IResult Update(AppoinmentCalendar calendar);
        IResult Add(AppoinmentCalendar calendar);
        IResult Delete(AppoinmentCalendar calendar);
    }
}
