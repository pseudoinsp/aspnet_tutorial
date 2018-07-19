using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PluralSightRestaurantAPI.Models;
using PluralSightRestaurantAPI.Services;
using PluralSightRestaurantAPI.ViewModels;

namespace PluralSightRestaurantAPI.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        public HomeController(IRestaurantData restaurantData, IGreeter greeter)
        {
            _restaurantData = restaurantData;
            _greeter = greeter;
        }

        [AllowAnonymous]
        public IActionResult Index()
        {
            var model = new HomeIndexViewModel();
            model.Restaurants = _restaurantData.GetAll();
            model.CurrentMessage = _greeter.GetMessageOfTheDay();

            return View(model);
        }

        public IActionResult Details(int id)
        {
            var model = _restaurantData.Get(id);
            //if (model == null) return NotFound();
            if (model == null) return RedirectToAction(nameof(Index));
            return View(model);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(RestaurantEditModel model)
        {
            if (ModelState.IsValid)
            {
                Restaurant newRestaurant = new Restaurant
                {
                    Name = model.Name,
                    Cuisine = model.Cuisine
                };

                newRestaurant = _restaurantData.Add(newRestaurant);

                //return View("Details", newRestaurant);
                // fix the form resubmit
                return RedirectToAction(nameof(Details), new { id = newRestaurant.Id });
            }
            else
            {
                // Error messages based on ModelState 
                return View();
            }
        }


        private IRestaurantData _restaurantData;
        private IGreeter _greeter;
    }


}
