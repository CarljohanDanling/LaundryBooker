namespace LaundryBooker.Api.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    [ApiController]
    [Route("api/values")]
    public class HomeController : ControllerBase
    {
        [HttpGet]
        public JsonResult Get()
            => new JsonResult("testing testing");
    }
}