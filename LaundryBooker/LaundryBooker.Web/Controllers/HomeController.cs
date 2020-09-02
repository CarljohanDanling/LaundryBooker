namespace LaundryBooker.Web.Controllers
{
    using Engine.Services;
    using Microsoft.AspNetCore.Mvc;

    public class HomeController : Controller
    {
        private readonly IBookingSessionService _bookingSessionService;

        public HomeController(IBookingSessionService bookingSessionService)
        {
            _bookingSessionService = bookingSessionService;
        }

        public IActionResult Index()
        {
            //var weekNumber = ISOWeek.GetWeekOfYear(DateTime.Today);
            return View();
        }

        [HttpGet]
        public IActionResult UpdateViewComponent(int weekNumber)
        {
            return ViewComponent("WeeklyScheduleComponent", weekNumber);
        }
    }
}