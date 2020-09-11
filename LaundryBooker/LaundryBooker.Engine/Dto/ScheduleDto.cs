namespace LaundryBooker.Engine.Dto
{
    using System;
    using System.Collections.Generic;
    using Models;

    public class ScheduleDto
    {
        public List<BookingSessionBL> Sessions { get; set; }
        public IEnumerable<DateTime> Days { get; set; }
        public int LaundryRoomId { get; set; }
        public int WeekNumber { get; set; }
    }
}