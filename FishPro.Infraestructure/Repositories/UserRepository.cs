using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FishPro.Core.Entities;
using FishPro.Infraestructure.Persistence;
using FishPro.Infraestructure.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FishPro.Infraestructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly FpDbContext _dbContext;
        public UserRepository(FpDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<User>> GetAllUsers()
        {
            return await _dbContext.Users.AsNoTracking().ToListAsync();
        }

        public async Task<User> GetUserById(int userId)
        {
            var user = await _dbContext.Users.SingleOrDefaultAsync(u => u.Id == userId);

            if(user == null) 
            { 
                return null;
            }

            return user;
        }

        public async Task<User> CreateUserAsync(User user)
        {
            _dbContext.Users.Add(user);
            await _dbContext.SaveChangesAsync();
            return user;
        }

        public async Task<User> UpdateUserAsync(User user)
        {
            _dbContext.Users.Update(user);
            await _dbContext.SaveChangesAsync();
            return user;
        }

        public async Task<bool> DeleteUserAsync(int userId)
        {
            var user = await _dbContext.Users.FindAsync(userId);

            if(user == null )
            {
                return false;
            }

            _dbContext.Users.Remove(user);
            await _dbContext.SaveChangesAsync();

            return true;
        }

    }
}
