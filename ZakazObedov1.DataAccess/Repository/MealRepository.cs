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
    public class MealRepository : BaseRepository, IMealRepository
    {
        public MealRepository(ZakazObedov1DBContext valuationContext) : base(valuationContext)
        {
        }

        public async Task<int> Create(Meal meal)
        {
            await _zakazobedov1Context.Meals.AddAsync(meal);
            await _zakazobedov1Context.SaveChangesAsync();
            return meal.Id;
        }

        public async Task<List<Meal>> GetAll()
        {
            return await _zakazobedov1Context.Meals.ToListAsync();
        }

        public async Task<Meal> GetById(int id)
        {
            return await _zakazobedov1Context.Meals.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Meal> GetByName(string name)
        {
            return await _zakazobedov1Context.Meals.FirstOrDefaultAsync(x => x.Name == name);
        }

        public async Task<int> Update(Meal meal)
        {
            _zakazobedov1Context.Meals.Update(meal);
            await _zakazobedov1Context.SaveChangesAsync();
            return meal.Id;
        }

        public async Task<int> Delete(int id)
        {
            var meal = await _zakazobedov1Context.Meals.FirstOrDefaultAsync(x => x.Id == id);
            _zakazobedov1Context.Meals.Remove(meal);
            await _zakazobedov1Context.SaveChangesAsync();
            return id;
        }
    }
}
