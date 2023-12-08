using AutoMapper;
using ZakazObedov1.Entities;
using ZakzObedov1.ZakazDto;

namespace ZakazObedov1.Mappings
{
    public class RestaurantProfile:Profile
    {
        public RestaurantProfile()
        {
            CreateMap<Restaurant, RestaurantDto>().ReverseMap();
            CreateMap<Restaurant, CreateRestaurantDto>().ReverseMap();
        }
    }
}

