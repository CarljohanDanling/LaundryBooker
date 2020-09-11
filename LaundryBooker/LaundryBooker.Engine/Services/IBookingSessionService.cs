namespace LaundryBooker.Engine.Services
{
    using Dto;
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using DataLayer.Dto;

    public interface IBookingSessionService
    {
        Task<ScheduleDto> GetSchedule(int laundryRoomId, int weekNumber);

        Task<IEnumerable<BookingSessionDto>> GetLaundryRoomBookingSessionsWithinDateRange
            (int laundryRoomId, DateTime fromDate, DateTime toDate);

        Task<IEnumerable<BuildingDto>> GetBuildings();

        Task<bool> AddBookingSession(AddBookingSessionDto bookingSessionDto);
    }
}