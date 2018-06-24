using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PluralSightRestaurantAPI.Models;

namespace PluralSightRestaurantAPI.Services
{
    public class InMemoryRestaurantData : IRestaurantData
    {
        public InMemoryRestaurantData()
        {
            _restaurants = new List<Restaurant>
            {
                new Restaurant { Id=1, Name="Tommy's Restaurant"},
                new Restaurant { Id=2, Name="Timmy's Restaurant"},
                new Restaurant { Id=3, Name="Toby's Restaurant"},
                new Restaurant { Id=4, Name="John's Restaurant"},
                new Restaurant { Id=5, Name="Jim's Restaurant"},
            };
        }

        public IEnumerable<Restaurant> GetAll()
        {
            return _restaurants.OrderBy(r => r.Name);
        }

        List<Restaurant> _restaurants;
    }
}
