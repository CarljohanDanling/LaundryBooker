namespace LaundryBooker.DataLayer.Dto
{
    using Models;

    public class BuildingDto
    {
        public int Id { get; set; }
        public string StreetAddress { get; set; }
        public int HouseNumber { get; set; }
        public char HousePrefix { get; set; }

        public LaundryRoomModel LaundryRoom { get; set; }
    }
}