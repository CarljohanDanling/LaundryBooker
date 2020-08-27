namespace LaundryBooker.Api.Dto
{
    using System;

    public class BookingSessionDto
    {
        public Guid Id { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime{ get; set; }
        public string SessionStatus { get; set; }
        public int TenantId { get; set; }
        public int LaundryRoomId { get; set; }
    }
}