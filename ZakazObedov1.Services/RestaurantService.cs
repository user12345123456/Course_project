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
    public class RestaurantService : IRestaurantService
    {
        public readonly IRestaurantRepository _restaurantRepository;
        public readonly IMapper _mapper;

        public RestaurantService(IRestaurantRepository restaurantRepository, IMapper mapper)
        {
            _restaurantRepository = restaurantRepository;
            _mapper = mapper;
        }
        public async Task<int> Create(RestaurantDto restaurant)
        {
            var existedRestaurant = await _restaurantRepository.GetByName(restaurant.Name);

            if (existedRestaurant != null)
            {
                throw new Exception("Restaurant exist");
            }

            var restaurantToAdd = _mapper.Map<Restaurant>(restaurant);
            return await _restaurantRepository.Create(restaurantToAdd);
        }

        public async Task<List<RestaurantDto>> GetAll()
        {
            var restaurants = await _restaurantRepository.GetAll();
            return _mapper.Map<List<RestaurantDto>>(restaurants);
        }

        public async Task<RestaurantDto> GetById(int id)
        {
            var restaurant = await _restaurantRepository.GetById(id);

            return _mapper.Map<RestaurantDto>(restaurant);
        }

        public async Task<int> Update(RestaurantDto restaurant)
        {
            var restaurantToUpdate = await _restaurantRepository.GetById(restaurant.Id)
                ?? throw new Exception("Restaurant not exist");

            restaurantToUpdate = _mapper.Map(restaurant, restaurantToUpdate);
            return await _restaurantRepository.Update(restaurantToUpdate);
        }
    }
}
