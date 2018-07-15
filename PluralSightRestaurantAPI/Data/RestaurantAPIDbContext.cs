using Microsoft.EntityFrameworkCore;
using PluralSightRestaurantAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PluralSightRestaurantAPI.Data
{
    public class RestaurantAPIDbContext : DbContext
    {
        public RestaurantAPIDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Restaurant> Restaurants { get; set; }
    }
}
