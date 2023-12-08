using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZakazObedov1.Entities;

namespace ZakazObedov1.DataAccess.Repository.Contracts
{
    public interface IUserRepository
    {
        Task<User> GetById(int id);
        Task<User> GetByName(string name);
        Task<List<User>> GetAll();
        Task<int> Create(User user);
        Task<int> Update(User user);
        Task<int> Delete(int id);
    }
}
