using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ZakazObedov1.DataAccess;
using ZakazObedov1.Entities;

namespace ZakazObedov1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrderController: ControllerBase
    {
        public readonly ZakazObedov1DBContext _zakazobedov1Context;

        public OrderController(ZakazObedov1DBContext zakazobedov1Context)
        {
            _zakazobedov1Context = zakazobedov1Context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Order>>> GetAll()
        {
            return await _zakazobedov1Context.Orders.ToListAsync();
        }

        [HttpPost]
        public async Task<ActionResult<int>> Create([FromBody] Order order)
        {
            await _zakazobedov1Context.Orders.AddAsync(order);
            await _zakazobedov1Context.SaveChangesAsync();
            return order.ID;
        }
    }
}
