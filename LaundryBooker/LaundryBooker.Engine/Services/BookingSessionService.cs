namespace LaundryBooker.Engine.Services
{
    using System;
    using DataLayer.Dto;
    using DataLayer.Repository;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class BookingSessionService : IBookingSessionService
    {
        private readonly IBookingSessionRepository _bookingSessionRepository;

        public BookingSessionService(IBookingSessionRepository bookingSessionRepository)
        {
            _bookingSessionRepository = bookingSessionRepository;
        }

        public async Task<IEnumerable<BookingSessionDto>> GetBookingSessions()
        {
            return await _bookingSessionRepository.GetBookingSessions();
        }

        public async Task<IEnumerable<BookingSessionDto>> GetBookingSessionsWithinDateRange(DateTime fromDate, DateTime toDate)
        {
            return await _bookingSessionRepository.GetBookingSessionsWithinDateRange(fromDate, toDate);
        }

        private void TestMethod()
        {
            //
        }
    }
}