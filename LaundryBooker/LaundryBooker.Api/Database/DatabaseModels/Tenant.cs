namespace LaundryBooker.Api.Database.DatabaseModels
{
    public class Tenant
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public Apartment Apartment { get; set; }
        public int ApartmentId { get; set; }

        public virtual BookingSession BookingSession { get; set; }
    }
}