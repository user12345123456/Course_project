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
    public class RestaurantRepository : BaseRepository, IRestaurantRepository
    {
        public RestaurantRepository(ZakazObedov1DBContext valuationContext) : base(valuationContext)
        {
        }

        public async Task<int> Create(Restaurant restaurant)
        {
            await _zakazobedov1Context.Restaurants.AddAsync(restaurant);
            await _zakazobedov1Context.SaveChangesAsync();
            return restaurant.Id;
        }

        public async Task<List<Restaurant>> GetAll()
        {
            return await _zakazobedov1Context.Restaurants.ToListAsync();
        }

        public async Task<Restaurant> GetById(int id)
        {
            return await _zakazobedov1Context.Restaurants.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Restaurant> GetByName(string name)
        {
            return await _zakazobedov1Context.Restaurants.FirstOrDefaultAsync(x => x.Name == name);
        }

        public async Task<int> Update(Restaurant restaurant)
        {
            _zakazobedov1Context.Restaurants.Update(restaurant);
            await _zakazobedov1Context.SaveChangesAsync();
            return restaurant.Id;
        }
        public async Task<int> Delete(int id)
        {
            var restaurant = await _zakazobedov1Context.Restaurants.FirstOrDefaultAsync(x => x.Id == id);
            _zakazobedov1Context.Restaurants.Remove(restaurant);
            await _zakazobedov1Context.SaveChangesAsync();
            return id;
        }
    }
}
