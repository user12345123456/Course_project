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

    public class UserRepository : BaseRepository, IUserRepository
    {
        public UserRepository(ZakazObedov1DBContext zakazobedov1Context) : base(zakazobedov1Context)
        {
        }
        public async Task<int> Create(User user)
        {
            await _zakazobedov1Context.Users.AddAsync(user);
            await _zakazobedov1Context.SaveChangesAsync();
            return user.Id;
        }

        public async Task<List<User>> GetAll()
        {
            return await _zakazobedov1Context.Users.ToListAsync();
        }

        public async Task<User> GetById(int id)
        {
            return await _zakazobedov1Context.Users.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<User> GetByName(string name)
        {
            return await _zakazobedov1Context.Users.FirstOrDefaultAsync(x => x.Name == name);
        }

        public async Task<int> Update(User user)
        {
            _zakazobedov1Context.Users.Update(user);
            await _zakazobedov1Context.SaveChangesAsync();
            return user.Id;
        }
        public async Task<int> Delete(int id)
        {
            var user = await _zakazobedov1Context.Users.FirstOrDefaultAsync(x => x.Id == id);
            _zakazobedov1Context.Users.Remove(user);
            await _zakazobedov1Context.SaveChangesAsync();
            return id;
        }
    }
}
