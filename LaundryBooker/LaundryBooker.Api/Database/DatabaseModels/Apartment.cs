namespace LaundryBooker.Api.Database.DatabaseModels
{
    public class Apartment
    {
        public int Id { get; set; }
        public int ApartmentNumber { get; set; }

        public Tenant Tenant { get; set; }
        public Building Building{ get; set; }
    }
}