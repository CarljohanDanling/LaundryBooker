namespace LaundryBooker.Api.Database.DatabaseModels
{
    using System.Collections.Generic;

    public class Tenant
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public Apartment Apartment { get; set; }
        public int ApartmentId { get; set; }

        public ICollection<BookingSession> BookingSessions { get; set; }
    }
}