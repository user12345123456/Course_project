using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZakazObedov1.DataAccess.Repository;
using ZakazObedov1.DataAccess.Repository.Contracts;
using ZakazObedov1.Entities;
using ZakazObedov1.Services.Contract;
using ZakzObedov1.ZakazDto;

namespace ZakazObedov1.Services
{
    public class OrderService : IOrderService
    {
        public readonly IOrderRepository _orderRepository;
        public readonly IMapper _mapper;

        public OrderService(IOrderRepository orderRepository, IMapper mapper)
        {
            _orderRepository = orderRepository;
            _mapper = mapper;
        }

        public async Task<int> Create(OrderDto order)
        {
            var existedOrder = await _orderRepository.GetById(order.ID);

            if (existedOrder != null)
            {
                throw new Exception("Order exist");
            }

            var orderToAdd = _mapper.Map<Order>(order);
            return await _orderRepository.Create(orderToAdd);
        }

        public async Task<List<OrderDto>> GetAll()
        {
            var orders = await _orderRepository.GetAll();
            return _mapper.Map<List<OrderDto>>(orders);
        }

        public async Task<OrderDto> GetById(int id)
        {
            var order = await _orderRepository.GetById(id);

            return _mapper.Map<OrderDto>(order);
        }

        public async Task<int> Update(OrderDto order)
        {
            var orderToUpdate = await _orderRepository.GetById(order.ID)
                ?? throw new Exception("Order not exist");

            orderToUpdate = _mapper.Map(order, orderToUpdate);
            return await _orderRepository.Update(orderToUpdate);
        }

    }
}
