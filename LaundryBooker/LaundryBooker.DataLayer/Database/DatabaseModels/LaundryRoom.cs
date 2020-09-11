namespace LaundryBooker.DataLayer.Database.DatabaseModels
{
    using System.Collections.Generic;
    using Enumerations;

    public class LaundryRoom
    {
        public int Id { get; set; }
        public int BuildingId { get; set; }
        public Building Building { get; set; }

        public LaundryRoomStatus RoomStatus { get; set; }
        public ICollection<BookingSession> BookingSessions { get; set; }
    }
}