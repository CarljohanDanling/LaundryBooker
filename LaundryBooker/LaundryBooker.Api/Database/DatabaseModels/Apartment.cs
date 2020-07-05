namespace LaundryBooker.Api.Database.DatabaseModels
{
    public class Apartment
    {
        public int Id { get; set; }
        public int ApartmentNumber { get; set; }

        public Building Building{ get; set; }
        public int BuildingId { get; set; }
        
        public virtual Tenant Tenant { get; set; }
    }
}