namespace LaundryBooker.Engine.Services
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using DataLayer.Dto;

    public interface IBookingSessionService
    {
        Task<IEnumerable<BookingSessionDto>> GetBookingSessions();
        Task<IEnumerable<BookingSessionDto>> GetBookingSessionsWithinDateRange(DateTime fromDate, DateTime toDate);
    }
}