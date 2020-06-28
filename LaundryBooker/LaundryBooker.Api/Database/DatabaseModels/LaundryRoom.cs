namespace LaundryBooker.Api.Database.DatabaseModels
{
    using System.Collections.Generic;

    public class LaundryRoom
    {
        public int Id { get; set; }

        public Building Building { get; set; }
        public int BuildingId { get; set; }

        public ICollection<BookingSession> BookingSessions { get; set; }
    }
}