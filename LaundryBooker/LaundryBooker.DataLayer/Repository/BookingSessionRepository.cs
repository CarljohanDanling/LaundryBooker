namespace LaundryBooker.DataLayer.Repository
{
    using AutoMapper;
    using Models;
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
        private readonly IMapper _mapper;

        public BookingSessionRepository(LaundryContext laundryContext, IMapper mapper)
        {
            _laundryContext = laundryContext;
            _mapper = mapper;
        }

        public async Task<IEnumerable<BookingSessionDto>> GetLaundryRoomBookingSessionsWithinDateRange
            (int laundryRoomId, DateTime fromDate, DateTime toDate)
        {
            var scheduledSessions = await _laundryContext.BookingSessions
                .Where(bs =>
                    bs.StartTime >= fromDate &&
                    bs.EndTime.Date <= toDate.Date &&
                    bs.SessionStatus == BookingSessionStatus.Scheduled &&
                    bs.LaundryRoomId == laundryRoomId)
                .ToListAsync();

            return _mapper.Map<List<BookingSessionDto>>(scheduledSessions);
        }

        public async Task<IEnumerable<BuildingDto>> GetBuildings()
        {
            var buildings = await _laundryContext.Buildings.Include(b => b.LaundryRoom)
                .AsNoTracking()
                .ToListAsync();

            var buildingsDto = _mapper.Map<List<BuildingDto>>(buildings);

            return buildingsDto;
        }

        public async Task<bool> AddBookingSession(AddBookingSessionModel addBookingSession)
        {
            var bookingSession = _mapper.Map<BookingSession>(addBookingSession);

            await _laundryContext.BookingSessions.AddAsync(bookingSession);
            var success = await _laundryContext.SaveChangesAsync();

            return success > 0;
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