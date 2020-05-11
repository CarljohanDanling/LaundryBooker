namespace LaundryBooker.Data.Models
{
    using System;

    public class AvailableSession
    {
        public int Id { get; set; }
        public DateTimeOffset StartTime { get; set; }
        public DateTimeOffset EndTime { get; set; }

        // Maybe some time span here instead of start- and endtime....?
    }
}