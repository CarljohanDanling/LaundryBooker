namespace LaundryBooker.DataLayer.Models
{
    using System;

    public class AddBookingSessionModel
    {
        public DateTimeOffset StartTime { get; set; }
        public DateTimeOffset EndTime { get; set; }
        public string SessionStatus { get; set; }
        public int TenantId { get; set; }
        public int LaundryRoomId { get; set; }
    }
}