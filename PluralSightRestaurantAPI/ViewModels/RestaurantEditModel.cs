using PluralSightRestaurantAPI.Models;
using System.ComponentModel.DataAnnotations;

namespace PluralSightRestaurantAPI.ViewModels
{
    public class RestaurantEditModel
    {
        [Required, MaxLength(80)]
        public string Name { get; set; }
        public CuisineType Cuisine { get; set; }
    }
}
