namespace LaundryBooker.DataLayer.Repository
{
    using Database.Enumerations;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Database.DatabaseContext;
    using Database.DatabaseModels;
    using Dto;
    using Microsoft.EntityFrameworkCore;

    public class BookingSessionRepository : IBookingSessionRepository
    {
        private readonly LaundryContext _laundryContext;

        public BookingSessionRepository(LaundryContext laundryContext)
        {
            _laundryContext = laundryContext;
        }

        public async Task<IEnumerable<BookingSessionDto>> GetBookingSessionsWithinDateRange(DateTime fromDate, DateTime toDate)
        {
            var scheduledSessions = await _laundryContext.BookingSessions
                .Where(bs =>
                    bs.StartTime >= fromDate &&
                    bs.EndTime <= toDate &&
                    bs.SessionStatus == BookingSessionStatus.Scheduled
                )
                .ToListAsync();

            var scheduledSessionsDto = new List<BookingSessionDto>();

            foreach (var bs in scheduledSessions)
            {
                scheduledSessionsDto.Add(new BookingSessionDto
                {
                    Id = bs.Id,
                    StartTime = bs.StartTime,
                    EndTime = bs.EndTime,
                    SessionStatus = bs.SessionStatus.ToString(),
                    LaundryRoomId = bs.LaundryRoomId,
                    TenantId = bs.TenantId
                }
                );
            }

            return scheduledSessionsDto;
        }

        public async Task<IEnumerable<BookingSessionDto>> GetBookingSessions()
        {
            var bookingSessions = await _laundryContext.BookingSessions.ToListAsync();
            var bookingSessionsDto = new List<BookingSessionDto>();

            foreach (var bs in bookingSessions)
            {
                bookingSessionsDto.Add(new BookingSessionDto
                {
                    Id = bs.Id,
                    StartTime = bs.StartTime,
                    EndTime = bs.EndTime,
                    SessionStatus = bs.SessionStatus.ToString(),
                    LaundryRoomId = bs.LaundryRoomId,
                    TenantId = bs.TenantId
                }
                );
            }

            return bookingSessionsDto;
        }

        public async Task<BookingSessionDto> GetBookingSession(Guid bookingSessionId)
        {
            var bookingSession = await _laundryContext.BookingSessions
                .Where(bs => bs.Id == bookingSessionId)
                .FirstOrDefaultAsync();

            return new BookingSessionDto
            {
                Id = bookingSession.Id,
                StartTime = bookingSession.StartTime,
                EndTime = bookingSession.EndTime,
                SessionStatus = bookingSession.SessionStatus.ToString(),
                LaundryRoomId = bookingSession.LaundryRoomId,
                TenantId = bookingSession.TenantId
            };
        }

        public void AddBookingSession(BookingSession bookingSession)
        {
            throw new NotImplementedException();
        }

        public void UpdateBookingSession(BookingSession bookingSession)
        {
            throw new NotImplementedException();
        }

        public void DeleteBookingSession(Guid bookingSessionId)
        {
            throw new NotImplementedException();
        }
    }
}