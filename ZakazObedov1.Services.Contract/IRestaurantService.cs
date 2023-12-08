using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZakzObedov1.ZakazDto;

namespace ZakazObedov1.Services.Contract
{
    public interface IRestaurantService
    {
        Task<RestaurantDto> GetById(int id);
        Task<List<RestaurantDto>> GetAll();

        Task<int> Create(RestaurantDto restaurant);

        Task<int> Update(RestaurantDto restaurant);
    }
}
