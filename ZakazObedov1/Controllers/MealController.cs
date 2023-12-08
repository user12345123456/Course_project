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
    [Route("[controller]")]
    public class MealController : ControllerBase
    {
        public readonly IMealService _mealService;
        public MealController(IMealService mealService)
        {
            _mealService = mealService;
        }

        [HttpGet]
        public async Task<ActionResult<List<MealDto>>> GetAll()
        {
            return await _mealService.GetAll();
        }

        [HttpPost]
        public async Task<ActionResult<int>> Create([FromBody] MealDto meal)
        {
            return await _mealService.Create(meal);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<MealDto>> GetById(int id)
        {
            return await _mealService.GetById(id);
        }
        [HttpPut]
        public async Task<ActionResult<int>> Update([FromBody] MealDto meal)
        {
            return await _mealService.Update(meal);
        }
    }
}
