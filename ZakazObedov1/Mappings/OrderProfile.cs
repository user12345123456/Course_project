using AutoMapper;
using ZakazObedov1.Entities;
using ZakzObedov1.ZakazDto;

namespace ZakazObedov1.Mappings
{
    public class OrderProfile:Profile
    {
        public OrderProfile()
        {
            CreateMap<Order, OrderDto>().ReverseMap();
            CreateMap<Order, CreateOrderDto>().ReverseMap();
        }
    }
}
