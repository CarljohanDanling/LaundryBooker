namespace LaundryBooker.Web.Models
{
    public class BuildingModel
    {
        public int Id { get; set; }
        public string StreetAddress { get; set; }
        public int HouseNumber { get; set; }
        public char HousePrefix { get; set; }
        public string BuildingName { get; set; }
        public int LaundryRoomId { get; set; }
    }
}