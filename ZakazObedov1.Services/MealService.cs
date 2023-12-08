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
    public class MealService : IMealService
    {
        public readonly IMealRepository _mealRepository;
        public readonly IMapper _mapper;

        public MealService(IMealRepository mealRepository, IMapper mapper)
        {
            _mealRepository = mealRepository;
            _mapper = mapper;
        }
        public async Task<int> Create(MealDto meal)
        {
            var existedMeal = await _mealRepository.GetByName(meal.Name);

            if (existedMeal != null)
            {
                throw new Exception("Meal exist");
            }

            var mealToAdd = _mapper.Map<Meal>(meal);
            return await _mealRepository.Create(mealToAdd);
        }

        public async Task<List<MealDto>> GetAll()
        {
            var meals = await _mealRepository.GetAll();
            return _mapper.Map<List<MealDto>>(meals);
        }

        public async Task<MealDto> GetById(int id)
        {
            var meal = await _mealRepository.GetById(id);

            return _mapper.Map<MealDto>(meal);
        }

        public async Task<int> Update(MealDto meal)
        {
            var mealToUpdate = await _mealRepository.GetById(meal.Id)
                ?? throw new Exception("Meal not exist");

            mealToUpdate = _mapper.Map(meal, mealToUpdate);
            return await _mealRepository.Update(mealToUpdate);
        }
    }
}
