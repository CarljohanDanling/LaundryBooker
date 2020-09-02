namespace LaundryBooker.DataLayer.Repository
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Database.DatabaseModels;
    using Dto;

    public interface IBookingSessionRepository
    {
        Task<IEnumerable<BookingSessionDto>> GetBookingSessions();
        Task<IEnumerable<BookingSessionDto>> GetBookingSessionsWithinDateRange(DateTime fromDate, DateTime toDate);
        Task<BookingSessionDto> GetBookingSession(Guid bookingSessionId);

        void AddBookingSession(BookingSession bookingSession);
        void UpdateBookingSession(BookingSession bookingSession);
        void DeleteBookingSession(Guid bookingSessionId);
    }
}