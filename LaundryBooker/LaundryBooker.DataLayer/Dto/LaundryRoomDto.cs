namespace LaundryBooker.DataLayer.Dto
{
    using System.Collections.Generic;
    using Database.DatabaseModels;

    public class LaundryRoomDto
    {
        public int Id { get; set; }
        public int BuildingId { get; set; }
        public string RoomStatus { get; set; }

        public IEnumerable<BookingSession> BookingSessions { get; set; }
    }
}