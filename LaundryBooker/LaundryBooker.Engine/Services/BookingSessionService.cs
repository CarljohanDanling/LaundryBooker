namespace LaundryBooker.Engine.Services
{
    using DataLayer.Models;
    using AutoMapper;
    using System.Globalization;
    using System.Linq;
    using Dto;
    using Models;
    using System;
    using DataLayer.Dto;
    using DataLayer.Repository;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class BookingSessionService : IBookingSessionService
    {
        private readonly IBookingSessionRepository _bookingSessionRepository;
        private readonly IMapper _mapper;

        public BookingSessionService(IBookingSessionRepository bookingSessionRepository, IMapper mapper)
        {
            _bookingSessionRepository = bookingSessionRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<BookingSessionDto>> GetLaundryRoomBookingSessionsWithinDateRange
            (int laundryRoomId, DateTime fromDate, DateTime toDate)
        {
            return await _bookingSessionRepository.GetLaundryRoomBookingSessionsWithinDateRange(laundryRoomId, fromDate, toDate);
        }

        public async Task<IEnumerable<BuildingDto>> GetBuildings()
        {
            return await _bookingSessionRepository.GetBuildings();
        }

        public async Task<ScheduleDto> GetSchedule(int laundryRoomId, int weekNumber)
        {
            return await BuildSchedule(laundryRoomId, weekNumber);
        }

        public async Task<bool> AddBookingSession(AddBookingSessionDto bookingSessionDto)
        {
            var bookingSession = _mapper.Map<AddBookingSessionModel>(bookingSessionDto);
            bookingSession.SessionStatus = "Scheduled";

            var success = await _bookingSessionRepository.AddBookingSession(bookingSession);

            return success;
        }

        private async Task<ScheduleDto> BuildSchedule(int laundryRoomId, int weekNumber)
        {
            var dateRange = GetStartAndEndDateForWeek(weekNumber);
            var scheduledBookingSessions = await GetScheduledBookingSessions(laundryRoomId, dateRange);
            var constructedScheduledBookingSessions = ConstructScheduledBookingSessions(scheduledBookingSessions);
            var days = GetAllDaysForOneWeek(dateRange.FirstDayInWeek);

            var schedule = new List<BookingSessionBL>();

            foreach (var day in days)
            {
                var counter = 0;

                foreach (var bs in constructedScheduledBookingSessions)
                {
                    if (day != bs.StartTime.Date) continue;

                    schedule.Add(new BookingSessionBL
                    {
                        Id = bs.Id,
                        StartTime = bs.StartTime,
                        EndTime = bs.EndTime,
                        SessionStatus = bs.SessionStatus,
                        IsSessionScheduled = bs.IsSessionScheduled
                    });

                    counter++;
                }

                if (counter == 0)
                {
                    schedule.Add(CreateAvailableBookingSession(day, 7, 14));
                    schedule.Add(CreateAvailableBookingSession(day, 14, 21));
                }

                else if (counter == 1)
                {
                    schedule.Add(schedule.Any(s => s.StartTime.Hour != 7 && s.StartTime.Date == day.Date)
                        ? CreateAvailableBookingSession(day, 7, 14)
                        : CreateAvailableBookingSession(day, 14, 21));
                }
            }

            var orderedSchedule = schedule.OrderBy(s => s.StartTime).ToList();

            return new ScheduleDto()
            {
                Sessions = orderedSchedule,
                Days = days,
                LaundryRoomId = laundryRoomId,
                WeekNumber = weekNumber
            };
        }

        private async Task<IEnumerable<BookingSessionDto>> GetScheduledBookingSessions(int laundryRoomId, DateRange dateRange)
        {
            return await GetLaundryRoomBookingSessionsWithinDateRange(laundryRoomId, dateRange.FirstDayInWeek, dateRange.LastDayInWeek);
        }

        private DateRange GetStartAndEndDateForWeek(int week)
        {
            if (week < 1 || week > 53)
            {
                throw new ArgumentOutOfRangeException("The week parameter must be in the range 1 through 53");
            }

            var date = ISOWeek.ToDateTime(DateTime.Today.Year, week, DayOfWeek.Monday);

            return new DateRange
            {
                FirstDayInWeek = GetDateForSpecificDay(date),
                LastDayInWeek = GetDateForSpecificDay(date).AddDays(6)
            };
        }

        private IEnumerable<BookingSessionBL> ConstructScheduledBookingSessions(IEnumerable<BookingSessionDto> scheduledBookingSessions)
        {
            return scheduledBookingSessions.Select(bs => new BookingSessionBL
            {
                Id = bs.Id,
                StartTime = bs.StartTime,
                EndTime = bs.EndTime,
                SessionStatus = bs.SessionStatus,
                IsSessionScheduled = true
            });
        }

        private IEnumerable<DateTime> GetAllDaysForOneWeek(DateTime firstDayInWeek)
        {
            return Enumerable.Range(0, 7).Select(i => firstDayInWeek.AddDays(i));
        }

        private DateTime GetDateForSpecificDay(DateTime date)
        {
            var difference = date.DayOfWeek - DayOfWeek.Monday;

            if (difference < 0)
            {
                difference += 7;
            }

            return date.AddDays(-difference).Date;
        }

        private BookingSessionBL CreateAvailableBookingSession(DateTime day, int startHour, int endHour)
        {
            return new BookingSessionBL()
            {
                Id = Guid.NewGuid(),
                StartTime = new DateTime(day.Year, day.Month, day.Day, startHour, 0, 0),
                EndTime = new DateTime(day.Year, day.Month, day.Day, endHour, 0, 0),
                IsSessionScheduled = false
            };
        }
    }
}