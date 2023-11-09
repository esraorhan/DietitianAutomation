using Business.Abstract;
using DietitianWebUI.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DietitianWebUI.ViewComponents
{
    public class AdultMeetingsListViewComponent: ViewComponent
    {
        private IAdultMeetingService _meetingService;

        public AdultMeetingsListViewComponent(IAdultMeetingService meetingService)
        {
            _meetingService = meetingService;
        }

        public IViewComponentResult Invoke(int CustomerId)
        {
            var customermeetingList = _meetingService.GetList(CustomerId).Data;
            var model = new CustomerProfileViewModel
            {
                AdultMeetings = customermeetingList
                // CourseId = CourseId
            };
            return View(model);

        }
    }
}
