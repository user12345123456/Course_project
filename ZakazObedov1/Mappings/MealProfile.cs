using AutoMapper;
using ZakazObedov1.Entities;
using ZakzObedov1.ZakazDto;

namespace ZakazObedov1.Mappings
{
    public class MealProfile:Profile
    {
        public MealProfile()
        {
            CreateMap<Meal, MealDto>().ReverseMap();
            CreateMap<Meal, CreateMealDto>().ReverseMap();
        }
    }
}
