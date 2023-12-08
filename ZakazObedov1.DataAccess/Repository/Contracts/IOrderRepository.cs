using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZakazObedov1.Entities;

namespace ZakazObedov1.DataAccess.Repository.Contracts
{
    public interface IOrderRepository
    {
        Task<Order> GetById(int id);
        Task<List<Order>> GetAll();
        Task<int> Create(Order order);
        Task<int> Update(Order order);
        Task<int> Delete(int id);
    }
}
