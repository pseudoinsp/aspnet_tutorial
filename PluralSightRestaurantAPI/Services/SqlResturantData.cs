using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PluralSightRestaurantAPI.Data;
using PluralSightRestaurantAPI.Models;

namespace PluralSightRestaurantAPI.Services
{
    public class SqlResturantData : IRestaurantData
    {
        private RestaurantAPIDbContext _context;

        public SqlResturantData(RestaurantAPIDbContext context)
        {
            _context = context;
        }

        public Restaurant Add(Restaurant restaurant)
        {
            _context.Restaurants.Add(restaurant);

            // generally this should be somewhere else 
            _context.SaveChanges();

            return restaurant; 
        }

        public Restaurant Get(int id)
        {
            return _context.Restaurants.FirstOrDefault(r => r.Id == id);
        }

        public IEnumerable<Restaurant> GetAll()
        {
            return _context.Restaurants.OrderBy(r => r.Name);
        }

        public Restaurant Update(Restaurant restaurant)
        {
            _context.Attach(restaurant).State = EntityState.Modified;
            _context.SaveChanges();
            return restaurant;
        }
    }
}
