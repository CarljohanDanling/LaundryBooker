namespace LaundryBooker.Web.Controllers
{
    using AutoMapper;
    using ViewModels;
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Threading.Tasks;
    using Models;
    using Engine.Services;
    using Microsoft.AspNetCore.Mvc;
    using Engine.Dto;

    public class HomeController : Controller
    {
        private readonly IBookingSessionService _bookingSessionService;
        private readonly IMapper _mapper;

        public HomeController(IBookingSessionService bookingSessionService, IMapper mapper)
        {
            _bookingSessionService = bookingSessionService;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            var buildingsDto = await _bookingSessionService.GetBuildings();
            var buildings = _mapper.Map<List<BuildingModel>>(buildingsDto);

            return View(new BuildingViewModel { Buildings = buildings });
        }

        public async Task<IActionResult> Schedule(int laundryRoomId, int weekNumber)
        {
            if (laundryRoomId == 0)
            {
                return RedirectToAction("Index");
            }

            if (weekNumber == 0)
            {
                weekNumber = ISOWeek.GetWeekOfYear(DateTime.Today);
            }

            var schedule = await _bookingSessionService.GetSchedule(laundryRoomId, weekNumber);
            var scheduleViewModel = _mapper.Map<ScheduleViewModel>(schedule);

            return View(scheduleViewModel);
        }

        [HttpGet]
        public IActionResult ChangeWeek(ScheduleViewModel schedule, string weekSelector)
        {
            switch (weekSelector)
            {
                case "Previous week":
                    schedule.WeekNumber -= 1;
                    break;
                case "Next week":
                    schedule.WeekNumber += 1;
                    break;
            }

            return RedirectToAction("Schedule", 
                ReturnBasicParameters(schedule.LaundryRoomId, schedule.WeekNumber));
        }

        [HttpPost]
        public async Task<IActionResult> AddBookingSession(ScheduleViewModel schedule)
        {
            if (ModelState.IsValid)
            {
                // Hard coding tenantId for sake of testing...
                var addBookingSession = new AddBookingSessionDto
                {
                    StartTime = schedule.StartTime,
                    EndTime = schedule.EndTime,
                    TenantId = 2,
                    LaundryRoomId = 23
                };

                var success = await _bookingSessionService.AddBookingSession(addBookingSession);

                if (success)
                {
                    TempData["ReservationSuccess"] = NotificationMessage.ReservationSuccess;

                    return RedirectToAction("Schedule",
                        ReturnBasicParameters(schedule.LaundryRoomId, schedule.WeekNumber));
                }
            }

            TempData["ReservationError"] = NotificationMessage.ReservationError;

            return RedirectToAction("Schedule",
                ReturnBasicParameters(schedule.LaundryRoomId, schedule.WeekNumber));
        }

        private static BasicParameters ReturnBasicParameters(int laundryRoomId, int weekNumber)
        {
            return new BasicParameters
            {
                LaundryRoomId = laundryRoomId,
                WeekNumber = weekNumber
            };
        }
    }
}