using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ZakazObedov1.DataAccess;
using ZakazObedov1.Entities;

namespace ZakazObedov1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MealController : ControllerBase
    {
        public readonly ZakazObedov1DBContext _zakazobedov1Context;

        public MealController(ZakazObedov1DBContext zakazobedov1Context)
        {
            _zakazobedov1Context = zakazobedov1Context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Meal>>> GetAll()
        {
            return await _zakazobedov1Context.Meals.ToListAsync();
        }

        [HttpPost]
        public async Task<ActionResult<int>> Create([FromBody] Meal meal)
        {
            await _zakazobedov1Context.Meals.AddAsync(meal);
            await _zakazobedov1Context.SaveChangesAsync();
            return meal.Id;
        }
    }
}
