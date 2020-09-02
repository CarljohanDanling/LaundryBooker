namespace LaundryBooker.DataLayer.Database.DatabaseModels
{
    using System;
    using Enumerations;

    public class BookingSession
    {
        public Guid Id { get; set; }
        public DateTimeOffset StartTime { get; set; }
        public DateTimeOffset EndTime { get; set; }
        public BookingSessionStatus SessionStatus { get; set; }

        public int TenantId { get; set; }
        public Tenant Tenant { get; set; }

        public int LaundryRoomId { get; set; }
        public LaundryRoom LaundryRoom { get; set; }
    }
}
