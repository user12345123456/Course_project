using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZakazObedov1.Entities;

namespace ZakazObedov1.DataAccess.Repository.Contracts
{
    public interface IRestaurantRepository
    {
        Task<Restaurant> GetById(int id);
        Task<Restaurant> GetByName(string name);
        Task<List<Restaurant>> GetAll();
        Task<int> Create(Restaurant restaurant);
        Task<int> Update(Restaurant restaurant);
        Task<int> Delete(int id);
    }
}
