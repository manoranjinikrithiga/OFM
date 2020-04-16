using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SearchService.Models;

namespace SearchService.Data
{
    public class RestaurantSeed
    {
        public static async Task SeedAsync(RestaurantContext context)
        {
            context.Database.Migrate();
            if (!context.Restaurants.Any())
            {
                context.Restaurants.AddRange
                    (GetPreconfiguredRestaurants());
                await context.SaveChangesAsync();
            }
            
            if (!context.MenuItems.Any())
            {
                context.MenuItems.AddRange
                    (GetPreconfiguredMenuItems());
                context.SaveChanges();
            }

        }

        static IEnumerable<Restaurant> GetPreconfiguredRestaurants()
        {
            return new List<Restaurant>()
            {
                new Restaurant() { Name ="Zaitoon", Description="Zaitoon a Multicuisine restaurant",Location="Ashok Nagar",Distance=10,Cuisine="Mutlicuisine",Rating=4 },
                new Restaurant() { Name ="Wangs", Description="Wangs a Chienese restaurant",Location="Velacherry",Distance=10,Cuisine="Chienese",Rating=3 },
                new Restaurant() { Name ="Vasantha Bhavan", Description="Vasantha Bhavan a South Indian restaurant",Location="KK Nagar",Distance=10,Cuisine="South Indian",Rating=4 }                
            };
        }

       
        static IEnumerable<MenuItem> GetPreconfiguredMenuItems()
        {
            return new List<MenuItem>()
            {
                new MenuItem() {RestaurantId=3,DishName="Dosai",Description= "plain Dosai",Price= 98.50M },
                new MenuItem() {RestaurantId=3,DishName="Sambar",Description= "Sambar",Price= 38 },
                new MenuItem() {RestaurantId=3,DishName="Idly",Description= "Idly",Price= 58.50M },
                new MenuItem() {RestaurantId=3,DishName="Vadai",Description= "Vadai",Price= 38.50M },
                new MenuItem() {RestaurantId=3,DishName="Poori",Description= "Poori",Price= 48.50M },
                new MenuItem() {RestaurantId=1,DishName="Roti",Description= "Roti",Price= 40 },
                new MenuItem() {RestaurantId=1,DishName="Non",Description= "Non",Price= 98.50M },
                new MenuItem() {RestaurantId=1,DishName="Butter Chicken",Description= "Butter Chicken",Price= 150.5M },
                new MenuItem() {RestaurantId=1,DishName="Pepper Chicken",Description= "Pepper Chicken",Price= 180M },
                new MenuItem() {RestaurantId=2,DishName="Mutton Briyani",Description= "Mutton Briyani",Price= 220M },
                new MenuItem() {RestaurantId=2,DishName="Chicken Briyani",Description= "Chicken Briyani",Price= 175.5M },
                new MenuItem() {RestaurantId=2,DishName="Mixed fried rice",Description= "Mixed fried rice",Price= 190.5M },
                new MenuItem() {RestaurantId=2,DishName="Chilli Chicken",Description= "Chilli Chicken",Price= 130M },
                new MenuItem() {RestaurantId=2,DishName="Dragon Chicken",Description= "Dragon Chicken",Price= 150M },
                new MenuItem() {RestaurantId=3,DishName="Mini Idly",Description= "Mini Idly",Price= 90M },
                new MenuItem() {RestaurantId=3,DishName="Puttu",Description= "Puttu",Price= 60M },
                new MenuItem() {RestaurantId=3,DishName="Idiappam",Description= "Idiappam",Price= 50M }
            };
        }
    }
}
