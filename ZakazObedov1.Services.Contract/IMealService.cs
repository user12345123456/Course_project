using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZakzObedov1.ZakazDto;

namespace ZakazObedov1.Services.Contract
{
    public interface IMealService
    {
        Task<MealDto> GetById(int id);
        Task<List<MealDto>> GetAll();

        Task<int> Create(MealDto meal);

        Task<int> Update(MealDto meal);
        Task<int> Delete(int id);
    }
}
