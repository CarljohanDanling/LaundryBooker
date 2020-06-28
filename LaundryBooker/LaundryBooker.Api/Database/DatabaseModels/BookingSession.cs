namespace LaundryBooker.Api.Database.DatabaseModels
{
    using System;

    public class BookingSession
    {
        public int Id { get; set; }
        public DateTime DueDate { get; set; }
        public DateTimeOffset StartTime { get; set; }
        public DateTimeOffset EndTime { get; set; }

        public virtual Tenant Tenant { get; set; }

        public int LaundryRoomId { get; set; }
        public LaundryRoom LaundryRoom { get; set; }
    }
}
