using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZakzObedov1.ZakazDto;

namespace ZakazObedov1.Services.Contract
{
    public interface IOrderService
    {
        Task<OrderDto> GetById(int id);
        Task<List<OrderDto>> GetAll();

        Task<int> Create(OrderDto order);

        Task<int> Update(OrderDto order);
        Task<int> Delete(int id);
    }
}
