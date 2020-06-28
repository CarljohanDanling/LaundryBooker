namespace LaundryBooker.Api.Database.DatabaseModels
{
    public class Tenant
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public Apartment Apartment { get; set; }
        public int ApartmentId { get; set; }


        #nullable enable
        public virtual BookingSession? BookingSession { get; set; }
        public int? BookingSessionId { get; set; }
    }
}