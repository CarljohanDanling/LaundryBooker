namespace LaundryBooker.Web.Controllers
{
    using Engine.Services;
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using System.Threading.Tasks;
    using Models;
    using ViewModels;
    using Microsoft.AspNetCore.Mvc;

    public class BookingScheduleController : Controller
    {
        private readonly IBookingSessionService _bookingSessionService;

        public BookingScheduleController(IBookingSessionService bookingSessionService)
        {
            _bookingSessionService = bookingSessionService;
        }

        //public IActionResult Index()
        //{

        //    if (weekNumber == 0)
        //    {
        //        weekNumber = ISOWeek.GetWeekOfYear(DateTime.Today);
        //    }

        //    var weeklyBookingSessionsAndDaysOfWeek = await GetWeeklyBookingSessionsAndDaysOfWeek(weekNumber);
        //    var finalizedBookingSessionList = FinalizeBookingSessionList(weeklyBookingSessionsAndDaysOfWeek);

        //    return View(new BookerViewModel { BookingSchedule = finalizedBookingSessionList, WeekNumber = weekNumber });
        //}

    }
}