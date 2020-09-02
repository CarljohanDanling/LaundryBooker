namespace LaundryBooker.DataLayer.Database.DatabaseModels
{
    public class Apartment
    {
        public int Id { get; set; }
        public int ApartmentNumber { get; set; }

        public Building Building{ get; set; }
        public int BuildingId { get; set; }
        
        public Tenant Tenant { get; set; }
    }
}