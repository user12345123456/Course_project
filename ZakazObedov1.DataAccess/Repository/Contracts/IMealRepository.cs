using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZakazObedov1.Entities;

namespace ZakazObedov1.DataAccess.Repository.Contracts
{
    public interface IMealRepository
    {
        Task<Meal> GetById(int id);
        Task<Meal> GetByName(string name);
        Task<List<Meal>> GetAll();
        Task<int> Create(Meal meal);
        Task<int> Update(Meal meal);
        Task<int> Delete(int id);
    }
}
