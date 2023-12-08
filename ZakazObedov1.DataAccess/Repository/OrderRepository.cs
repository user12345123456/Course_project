using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZakazObedov1.DataAccess.Repository.Contracts;
using ZakazObedov1.Entities;

namespace ZakazObedov1.DataAccess.Repository
{
    public class OrderRepository : BaseRepository, IOrderRepository
    {
        public OrderRepository(ZakazObedov1DBContext valuationContext) : base(valuationContext)
        {
        }

        public async Task<int> Create(Order order)
        {
            await _zakazobedov1Context.Orders.AddAsync(order);
            await _zakazobedov1Context.SaveChangesAsync();
            return order.ID;
        }

        public async Task<List<Order>> GetAll()
        {
            return await _zakazobedov1Context.Orders.ToListAsync();
        }

        public async Task<Order> GetById(int id)
        {
            return await _zakazobedov1Context.Orders.FirstOrDefaultAsync(x => x.ID == id);
        }

        public async Task<int> Update(Order order)
        {
            _zakazobedov1Context.Orders.Update(order);
            await _zakazobedov1Context.SaveChangesAsync();
            return order.ID;
        }
        public async Task<int> Delete(int id)
        {
            var order = await _zakazobedov1Context.Orders.FirstOrDefaultAsync(x => x.ID == id);
            _zakazobedov1Context.Orders.Remove(order);
            await _zakazobedov1Context.SaveChangesAsync();
            return id;
        }
    }
}
