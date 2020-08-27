namespace LaundryBooker.Api.Services
{
    using LaundryBooker.Api.Database.DatabaseContext;
    using LaundryBooker.Api.Database.DatabaseModels;
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class BookingSessionRepository : IBookingSessionRepository
    {
        private readonly LaundryContext _laundryContext;

        public BookingSessionRepository(LaundryContext laundryContext)
        {
            _laundryContext = laundryContext;
        }

        public async Task<IEnumerable<BookingSession>> GetBookingSessions()
            => await _laundryContext.BookingSessions.ToListAsync();

        public async Task<BookingSession> GetBookingSession(Guid bookingSessionId)
            => await _laundryContext.BookingSessions
                .Where(bs => bs.Id == bookingSessionId)
                .FirstOrDefaultAsync();
    }
}