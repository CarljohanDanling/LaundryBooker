namespace LaundryBooker.DataLayer.Repository
{
    using Models;
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Database.DatabaseModels;
    using Dto;

    public interface IBookingSessionRepository
    {
        Task<IEnumerable<BookingSessionDto>> GetLaundryRoomBookingSessionsWithinDateRange
            (int laundryRoomId, DateTime fromDate, DateTime toDate);

        Task<IEnumerable<BuildingDto>> GetBuildings();

        Task<bool> AddBookingSession(AddBookingSessionModel addBookingSession);
        
        void UpdateBookingSession(BookingSession bookingSession);
        
        void DeleteBookingSession(Guid bookingSessionId);
    }
}