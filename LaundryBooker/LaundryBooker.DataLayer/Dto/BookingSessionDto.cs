namespace LaundryBooker.DataLayer.Dto
{
    using System;

    public class BookingSessionDto
    {
        public Guid Id { get; set; }
        public DateTimeOffset StartTime { get; set; }
        public DateTimeOffset EndTime { get; set; }
        public string SessionStatus { get; set; }

        public int TenantId { get; set; }
        public int LaundryRoomId { get; set; }
    }
}