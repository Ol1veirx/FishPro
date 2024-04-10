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
    public class StageRepository : IStageRepository
    {
        private readonly FpDbContext _dbContext;
        public StageRepository(FpDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Stage>> GetAllAsync()
        {
            return await _dbContext.Stages.AsNoTracking().ToListAsync();
        }

        public async Task<Stage> GetByIdAsync(int id)
        {
            var stage = await _dbContext.Stages.SingleOrDefaultAsync(s => s.Id == id);
            
            if (stage == null)
            {
                return null;
            }

            return stage;
        }
        public async Task<Stage> CreateAsync(Stage stage)
        {
           _dbContext.Stages.Add(stage);
            await _dbContext.SaveChangesAsync();
            return stage;
        }

        public async Task<Stage> UpdateAsync(Stage stage)
        {
            _dbContext.Stages.Update(stage);
            await _dbContext.SaveChangesAsync();
            return stage;
        }

        public async Task<Stage> DeleteAsync(int id)
        {
            var result = await _dbContext.Stages.FindAsync(id);

            if(result == null)
            {
                return null;
            }

            _dbContext.Stages.Remove(result);
            await _dbContext.SaveChangesAsync();

            return result;
        }

    }
}
