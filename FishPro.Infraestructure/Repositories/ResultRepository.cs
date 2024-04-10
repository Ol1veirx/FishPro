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
    public class ResultRepository : IResultRepository
    {
        private readonly FpDbContext _dbContext;
        public ResultRepository(FpDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Result>> GetAllAsync()
        {
            return await _dbContext.Results.AsNoTracking().ToListAsync();
        }

        public async Task<Result> GetByIdAsync(int id)
        {
            var result = await _dbContext.Results.SingleOrDefaultAsync(r => r.Id == id);

            if(result == null)
            {
                return null;
            }

            return result;
        }


        public async Task<Result> CreateAsync(Result result)
        {
            _dbContext.Results.Add(result);
            await _dbContext.SaveChangesAsync();
            return result;
        }

        public async Task<Result> UpdateAsync(Result result)
        {
            _dbContext.Results.Update(result);
            await _dbContext.SaveChangesAsync();
            return result;
        }

        public async Task<Result> DeleteAsync(int id)
        {
            var result = await _dbContext.Results.FindAsync(id);

            if(result == null)
            {
                return null;
            }

            _dbContext.Results.Remove(result); 
            await _dbContext.SaveChangesAsync();
            return result;
        }
    }
}
