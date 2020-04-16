using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SearchService.Data;
using SearchService.Repository;

namespace FOMApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SearchController : Controller
    {

        private readonly ISearchRepository _repository;

        public SearchController(ISearchRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        [Route("GetRestaurant")]
        public IActionResult GetRestaurant()
        {
            var restaurants = _repository.GetRestaurant();

            if (restaurants != null)
            {
                return Ok(restaurants);
            }
            return NotFound();
        }

        [HttpGet]
        [Route("GetRestaurantsbyId/{id:int}")]
        public IActionResult GetRestaurantsbyId(int id)
        {
            if (id <= 0)
            {
                return BadRequest();
            }
            var restaurant = _repository.GetRestaurantsbyId(id);

            if (restaurant != null)
            {
                return Ok(restaurant);
            }
            return NotFound();
        }

        
        [HttpGet]
        [Route("GetRestaurantsbyName/{restaurantName}")]
        public IActionResult GetRestaurantsbyName(string restaurantName)
        {
            if (String.IsNullOrEmpty(restaurantName))
            {
                return BadRequest();
            }
            var restaurants = _repository.GetRestaurantsbyName(restaurantName);

            if (restaurants != null)
            {
                return Ok(restaurants);
            }
            return NotFound();
        }


        [HttpGet]
        [Route("GetRestaurantsbyCuisine/{cuisine}")]
        public IActionResult GetRestaurantsbyCuisine(string cuisine)
        {
            if (String.IsNullOrEmpty(cuisine))
            {
                return BadRequest();
            }
            var restaurants = _repository.GetRestaurantsbyCuisine(cuisine);

            if (restaurants != null)
            {
                return Ok(restaurants);
            }
            return NotFound();
        }

        [HttpGet]
        [Route("GetRestaurantsbyDistance/{withinDistance:int}")]
        public IActionResult GetRestaurantsbyDistance(int withinDistance)
        {
            if (withinDistance <= 0)
            {
                return BadRequest();
            }
            var item = _repository.GetRestaurantsbyDistance(withinDistance);

            if (item != null)
            {
                return Ok(item);
            }
            return NotFound();
        }

        [HttpGet]
        [Route("GetRestaurantsbyLocation/{location}")]
        public IActionResult GetRestaurantsbyLocation(string location)
        {
            if (String.IsNullOrEmpty(location))
            {
                return BadRequest();
            }
            var restaurants = _repository.GetRestaurantsbyLocation(location);

            if (restaurants != null)
            {
                return Ok(restaurants);
            }
            return NotFound();
        }

        [HttpGet]
        [Route("GetRestaurantsbyRating/{minRating:int}")]
        public IActionResult GetRestaurantsbyRating(int minRating)
        {
            if (minRating <= 0)
            {
                return BadRequest();
            }
            var item = _repository.GetRestaurantsbyRating(minRating);

            if (item != null)
            {
                return Ok(item);
            }
            return NotFound();
        }

        [HttpGet]
        [Route("GetRestaurantsbyPrice/{minPrice:decimal}/{maxPrice:decimal}")]
        public IActionResult GetRestaurantsbyPrice(decimal minPrice, decimal maxPrice)
        {
            if (minPrice <= 0 || maxPrice <= 0 || minPrice > maxPrice)
            {
                return BadRequest();
            }
            var item = _repository.GetRestaurantsbyPrice(minPrice, maxPrice);

            if (item != null)
            {
                return Ok(item);
            }
            return NotFound();
        }


        [HttpGet]
        [Route("GetFoodItemsByName/{dishName}")]
        public IActionResult GetFoodItemsByName(string dishName)
        {
            if (String.IsNullOrEmpty(dishName))
            {
                return BadRequest();
            }
            var dishes = _repository.GetFoodItemsByName(dishName);

            if (dishes != null)
            {
                return Ok(dishes);
            }
            return NotFound();
        }
        
        [HttpGet]
        [Route("GetMenuByRestaurantId/{restaurantId:int}")]
        public IActionResult GetMenuByRestaurantId(int restaurantId)
        {
            if (restaurantId <= 0)
            {
                return BadRequest();
            }
            var item = _repository.GetMenuByRestaurantId(restaurantId);

            if (item != null)
            {
                return Ok(item);
            }
            return NotFound();
        }

    }
}