namespace LaundryBooker.Web.ViewModels
{
    using Models;
    using System.Collections.Generic;

    public class BookerViewModel
    {
        public List<DayWithSessionCollectionModel> BookingSchedule { get; set; }
    }
}