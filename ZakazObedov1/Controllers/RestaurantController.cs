using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ZakazObedov1.DataAccess;
using ZakazObedov1.Entities;

namespace ZakazObedov1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RestaurantController : ControllerBase
    {
        public readonly ZakazObedov1DBContext _zakazobedov1Context;

        public RestaurantController(ZakazObedov1DBContext zakazobedov1Context)
        {
            _zakazobedov1Context = zakazobedov1Context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Restaurant>> GetRestaurants()
        {
            return _zakazobedov1Context.Restaurants.ToList();
        }

        
        [HttpGet("{id}")]
        public ActionResult<Restaurant> GetRestaurant(int id)
        {
            var restaurant = _zakazobedov1Context.Restaurants.FirstOrDefault(r => r.Id == id);

            if (restaurant == null)
            {
                return NotFound();
            }

            return restaurant;
        }

        [HttpPost]
        public ActionResult<Restaurant> AddRestaurant(Restaurant restaurant)
        {
            _zakazobedov1Context.Restaurants.Add(restaurant);
            _zakazobedov1Context.SaveChanges();

            return CreatedAtAction(nameof(GetRestaurant), new { id = restaurant.Id }, restaurant);
        }

     
        [HttpPut("{id}")]
       /* public IActionResult UpdateRestaurant(int id, Restaurant newRestaurant)
        {
            var restaurant = _zakazobedov1Context.Restaurants.FirstOrDefault(r => r.Id == id);

            if (restaurant == null)
            {
                return NotFound();
            }

            restaurant.Name = newRestaurant.Name;
            restaurant.Address = newRestaurant.Address;
            restaurant.Meals = newRestaurant.Meals;

            _zakazobedov1Context.SaveChanges();

            return Ok();
        }*/

        [HttpDelete("{id}")]
        public IActionResult DeleteRestaurant(int id)
        {
            var restaurant = _zakazobedov1Context.Restaurants.FirstOrDefault(r => r.Id == id);

            if (restaurant == null)
            {
                return NotFound();
            }

            _zakazobedov1Context.Restaurants.Remove(restaurant);
            _zakazobedov1Context.SaveChanges();

            return Ok();
        }
    }
}
