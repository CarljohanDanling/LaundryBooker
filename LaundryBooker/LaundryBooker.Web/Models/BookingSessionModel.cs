namespace LaundryBooker.Web.Models
{
    using System;

    public class BookingSessionModel
    {
        public Guid Id { get; set; }
        public DateTimeOffset StartTime { get; set; }
        public DateTimeOffset EndTime { get; set; }
        public string SessionStatus { get; set; }
        public bool IsSessionScheduled { get; set; }
    }
}