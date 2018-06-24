using Microsoft.AspNetCore.Mvc;
using PluralSightRestaurantAPI.Models;
using PluralSightRestaurantAPI.Services;

namespace PluralSightRestaurantAPI.Controllers
{
    public class HomeController : Controller
    {
        public HomeController(IRestaurantData restaurantData)
        {
            _restaurantData = restaurantData;
        }

        public IActionResult Index()
        {
            var model = _restaurantData.GetAll();

            return View(model);
        }

        private IRestaurantData _restaurantData;
    }
}
