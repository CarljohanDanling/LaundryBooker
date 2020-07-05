namespace LaundryBooker.Api.Controllers
{
    using LaundryBooker.Api.Database.DatabaseContext;
    using Microsoft.AspNetCore.Mvc;

    [ApiController]
    [Route("api/values")]
    public class HomeController : ControllerBase
    {
        private readonly LaundryContext _laundryContext;

        public HomeController(LaundryContext laundryContext)
        {
            _laundryContext = laundryContext;
        }

        [HttpGet]
        public JsonResult Get()
            => new JsonResult("test");
    }
}