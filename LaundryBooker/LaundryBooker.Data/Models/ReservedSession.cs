namespace LaundryBooker.Data.Models
{
    using System;

    public class ReservedSession
    {
        public int Id { get; set; }
        public DateTimeOffset StartTime { get; set; }
        public DateTimeOffset EndTime { get; set; }
    }
}