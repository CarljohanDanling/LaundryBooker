namespace LaundryBooker.Web.ViewModels
{
    using System.ComponentModel.DataAnnotations;
    using System;
    using System.Collections.Generic;
    using Models;

    public class ScheduleViewModel
    {
        public List<BookingSessionModel> Sessions { get; set; }
        public IEnumerable<DateTime> Days { get; set; }

        [Required]
        public int LaundryRoomId { get; set; }

        [Required]
        public int WeekNumber { get; set; }

        [Required]
        public DateTimeOffset StartTime { get; set; }

        [Required]
        public DateTimeOffset EndTime { get; set; }

    }
}