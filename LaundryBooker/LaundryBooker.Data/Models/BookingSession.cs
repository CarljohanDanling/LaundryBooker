namespace LaundryBooker.Data.Models
{
    using System;

    public class BookingSession
    {
        public int Id { get; set; }
        public DateTime DueDate { get; set; }
        public DateTimeOffset StartTime { get; set; }
        public DateTimeOffset EndTime { get; set; }
    }
}