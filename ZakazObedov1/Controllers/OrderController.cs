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
    [Route("Order")]
    public class OrderController: ControllerBase
    {
        public readonly IOrderService _orderService;
        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpGet]
        public async Task<ActionResult<List<OrderDto>>> GetAll()
        {
            return await _orderService.GetAll();
        }

        [HttpPost]
        public async Task<ActionResult<int>> Create([FromBody] OrderDto order)
        {
            return await _orderService.Create(order);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<OrderDto>> GetById(int id)
        {
            return await _orderService.GetById(id);
        }
        [HttpPut]
        public async Task<ActionResult<int>> Update([FromBody] OrderDto order)
        {
            return await _orderService.Update(order);
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<int>> DeleteProductById(int id)
        {
            return await _orderService.Delete(id);
        }
    }
}
