namespace LaundryBooker.Web.Components
{
    using LaundryBooker.Web.ViewModels;
    using Microsoft.AspNetCore.Mvc;

    public class TestComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            var testViewModel = new TestViewModel
            {
                TestMessage = "Hello!"
            };

            return View(testViewModel);
        }
    }
}