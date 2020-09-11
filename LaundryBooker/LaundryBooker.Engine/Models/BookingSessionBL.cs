namespace LaundryBooker.Engine.Models
{
    using System;

    public class BookingSessionBL
    {
        public Guid Id { get; set; }
        public DateTimeOffset StartTime { get; set; }
        public DateTimeOffset EndTime { get; set; }
        public string SessionStatus { get; set; }
        public bool IsSessionScheduled { get; set; }
    }
}