using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PluralSightRestaurantAPI.Models;
using PluralSightRestaurantAPI.Services;

namespace PluralSightRestaurantAPI.Pages
{
    public class GreetingModel : PageModel
    {
        private IGreeter _greeter;
        private IRestaurantData _restaurantData;

        public string CurrentGreeting { get; set; }
        public IEnumerable<Restaurant> Restaurants { get; private set; }

        public GreetingModel(IGreeter greeter, IRestaurantData restaurantData)
        {
            _greeter = greeter;
            _restaurantData = restaurantData;
        }

        public void OnGet(string name)
        {
            CurrentGreeting = $"{name}: {_greeter.GetMessageOfTheDay()}";

            Restaurants = _restaurantData.GetAll();

        }
    }
}