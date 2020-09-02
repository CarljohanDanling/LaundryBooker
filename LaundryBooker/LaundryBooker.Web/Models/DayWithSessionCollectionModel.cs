namespace LaundryBooker.Web.Models
{
    using System;
    using System.Collections.Generic;

    public class DayWithSessionCollectionModel
    {
        public DateTime Day { get; set; }
        public List<BookingSessionModel> BookingSessions { get; set; }
    }
}