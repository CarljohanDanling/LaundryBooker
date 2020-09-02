namespace LaundryBooker.Web.Components
{
    using System.Globalization;
    using System;
    using System.Linq;
    using Engine.Services;
    using System.Threading.Tasks;
    using System.Collections.Generic;
    using Models;
    using ViewModels;
    using Microsoft.AspNetCore.Mvc;

    public class WeeklyScheduleComponent : ViewComponent
    {
        private readonly IBookingSessionService _bookingSessionService;

        public WeeklyScheduleComponent(IBookingSessionService bookingSessionService)
        {
            _bookingSessionService = bookingSessionService;
        }

        public async Task<IViewComponentResult> InvokeAsync(int weekNumber)
        {
            var weeklyBookingSessionsAndDaysOfWeek = await GetWeeklyBookingSessionsAndDaysOfWeek(weekNumber);
            var finalizedBookingSessionList = FinalizeBookingSessionList(weeklyBookingSessionsAndDaysOfWeek);

            return View(new BookerViewModel { BookingSchedule = finalizedBookingSessionList });
        }

        private List<DayWithSessionCollectionModel> FinalizeBookingSessionList
            (Tuple<List<BookingSessionModel>, IEnumerable<DateTime>> bookingSessionsAndDaysOfWeek)
        {
            var daysOfWeek = bookingSessionsAndDaysOfWeek.Item2;
            var bookingSessions = bookingSessionsAndDaysOfWeek.Item1;

            var finalizedBookingSessionList = new List<DayWithSessionCollectionModel>();

            foreach (var day in daysOfWeek)
            {
                var tempBookingSessions = new List<BookingSessionModel>();
                var availableSessions = new List<BookingSessionModel>();

                foreach (var bs in bookingSessions)
                {
                    if (day.Date == bs.StartTime.Date)
                    {
                        tempBookingSessions.Add(new BookingSessionModel
                        {
                            Id = bs.Id,
                            StartTime = bs.StartTime,
                            EndTime = bs.EndTime,
                            SessionStatus = bs.SessionStatus,
                            IsSessionScheduled = true
                        });
                    }
                }

                if (tempBookingSessions.Count == 0)
                {
                    availableSessions.Add(CreateAvailableBookingSession(day, 7, 14));
                    availableSessions.Add(CreateAvailableBookingSession(day, 14, 21));
                }

                else
                {
                    if (tempBookingSessions.Any(x => x.StartTime.Hour != 7))
                    {
                        availableSessions.Add(CreateAvailableBookingSession(day, 7, 14));
                    }

                    else
                    {
                        availableSessions.Add(CreateAvailableBookingSession(day, 14, 21));
                    }
                }

                var allSessionsOrdered = tempBookingSessions
                    .Concat(availableSessions)
                    .OrderBy(s => s.StartTime)
                    .ToList();

                finalizedBookingSessionList.Add(new DayWithSessionCollectionModel
                {
                    Day = day,
                    BookingSessions = allSessionsOrdered
                });
            }

            return finalizedBookingSessionList;
        }

        private BookingSessionModel CreateAvailableBookingSession(DateTime day, int startHour, int endHour)
        {
            return new BookingSessionModel()
            {
                Id = Guid.NewGuid(),
                StartTime = new DateTime(day.Year, day.Month, day.Day, startHour, 0, 0),
                EndTime = new DateTime(day.Year, day.Month, day.Day, endHour, 0, 0),
                IsSessionScheduled = false
            };
        }

        private async Task<Tuple<List<BookingSessionModel>, IEnumerable<DateTime>>> GetWeeklyBookingSessionsAndDaysOfWeek(int chosenWeek)
        {
            var chosenPeriod = ISOWeek.ToDateTime(DateTime.Today.Year, chosenWeek, DayOfWeek.Monday);

            var firstDayInWeek = GetTheDateFromFirstDayInWeek(chosenPeriod);
            var lastDayInWeek = GetTheDateFromFirstDayInWeek(chosenPeriod).AddDays(6);

            var allDaysForTheWeek = Enumerable.Range(0, 7)
                .Select(i => firstDayInWeek
                    .AddDays(i)
                );

            var bookingSessionsDto = await _bookingSessionService
                .GetBookingSessionsWithinDateRange(firstDayInWeek, lastDayInWeek);

            var bookingSessionsModel = new List<BookingSessionModel>();

            bookingSessionsDto.ToList().ForEach(s =>
                bookingSessionsModel.Add(new BookingSessionModel
                {
                    Id = s.Id,
                    StartTime = s.StartTime,
                    EndTime = s.EndTime,
                    SessionStatus = s.SessionStatus
                }
                )
            );

            return Tuple.Create(bookingSessionsModel, allDaysForTheWeek);
        }

        private DateTime GetTheDateFromFirstDayInWeek(DateTime chosenPeriod)
        {
            var chosenDateTime = chosenPeriod.Date;
            var difference = chosenDateTime.DayOfWeek - DayOfWeek.Monday;

            if (difference < 0)
            {
                difference += 7;
            }

            return chosenDateTime.AddDays(-difference).Date;
        }
    }
}