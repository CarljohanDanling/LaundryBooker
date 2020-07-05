namespace LaundryBooker.Api.Database.DatabaseModels
{
    using LaundryBooker.Api.Database.Enumerations;
    using System.Collections.Generic;

    public class LaundryRoom
    {
        public int Id { get; set; }

        public int BuildingId { get; set; }
        public Building Building { get; set; }

        public LaundryRoomStatus RoomStatus { get; set; }
        public ICollection<BookingSession> BookingSessions { get; set; }
    }
}