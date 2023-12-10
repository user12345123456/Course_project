using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ZakazObedov1.DataAccess;
using ZakazObedov1.Entities;
using ZakazObedov1.Services;
using ZakazObedov1.Services.Contract;
using ZakzObedov1.ZakazDto;

namespace ZakazObedov1.Controllers
{
    [ApiController]
    [Route("Restaurant")]
    public class RestaurantController : ControllerBase
    {
        public readonly IRestaurantService _restaurantService;
        public RestaurantController(IRestaurantService restaurantService)
        {
            _restaurantService = restaurantService;
        }

        [HttpGet]
        public async Task<ActionResult<List<RestaurantDto>>> GetAll()
        {
            return await _restaurantService.GetAll();
        }

        [HttpPost]
        public async Task<ActionResult<int>> Create([FromBody] RestaurantDto restaurant)
        {
            return await _restaurantService.Create(restaurant);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<RestaurantDto>> GetById(int id)
        {
            return await _restaurantService.GetById(id);
        }
        [HttpPut]
        public async Task<ActionResult<int>> Update([FromBody] RestaurantDto restaurant)
        {
            return await _restaurantService.Update(restaurant);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<int>> DeleteProductById(int id)
        {
            return await _restaurantService.Delete(id);
        }
    }
}
