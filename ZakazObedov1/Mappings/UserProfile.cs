using AutoMapper;
using ZakazObedov1.Entities;
using ZakzObedov1.ZakazDto;

namespace ZakazObedov1.Mappings
{
    public class UserProfile:Profile
    {
        public UserProfile()
        {
            CreateMap<User, UserDto>().ReverseMap();
            CreateMap<User, CreateUserDto>().ReverseMap();
        }
    }
}
