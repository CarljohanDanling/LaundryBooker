using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LaundryBooker.Web.Components
{
    public class TestViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
            => View("I'm a ViewComponent!");
    }
}
