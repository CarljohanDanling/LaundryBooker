namespace LaundryBooker.Api.Services
{
    using LaundryBooker.Api.Database.DatabaseModels;
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IBookingSessionRepository
    {
        Task<IEnumerable<BookingSession>> GetBookingSessions();
        Task<BookingSession> GetBookingSession(Guid bookingSessionId);
    }
}