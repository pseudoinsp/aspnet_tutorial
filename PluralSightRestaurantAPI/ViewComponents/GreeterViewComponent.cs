using Microsoft.AspNetCore.Mvc;
using PluralSightRestaurantAPI.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PluralSightRestaurantAPI.ViewComponents
{
    public class GreeterViewComponent : ViewComponent
    {
        private IGreeter _greeter;

        public GreeterViewComponent(IGreeter greeter)
        {
            _greeter = greeter;
        }

        public IViewComponentResult Invoke()
        {
            string model = _greeter.GetMessageOfTheDay();
            // without "Default" as the name of the view, the string model would be interpreted as the name of the view
            return View("Default", model);
        }
    }
}
