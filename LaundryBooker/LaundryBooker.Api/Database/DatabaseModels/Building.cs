namespace LaundryBooker.Api.Database.DatabaseModels
{
    using System.Collections.Generic;

    public class Building
    {
        public int Id { get; set; }
        public string StreetAddress { get; set; }
        public int HouseNumber { get; set; }
        public char HousePrefix { get; set; }

        public LaundryRoom LaundryRoom { get; set; }
        public ICollection<Apartment> Apartments { get; set; }
    }
}