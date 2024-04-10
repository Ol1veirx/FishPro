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
    public class TeamRepository : ITeamRepository
    {
        private readonly FpDbContext _dbContext;
        public TeamRepository(FpDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Team>> GetAllAsync()
        {
            return await _dbContext.Teams.Include(t => t.Results).AsNoTracking().ToListAsync(); 
        }

        public async Task<Team> GetByIdAsync(int id)
        {
            var team = await _dbContext.Teams.SingleOrDefaultAsync(t => t.Id == id);

            if(team == null)
            {
                return null;
            }

            return team;
        }

        public async Task<Team> CreateAsync(Team team)
        {
            _dbContext.Teams.Add(team);
            await _dbContext.SaveChangesAsync();
            return team;
        }

        public async Task<Team> UpdateAsync(Team team)
        {
            _dbContext.Teams.Update(team);
            await _dbContext.SaveChangesAsync();
            return team;
        }

        public async Task<Team> DeleteAsync(int id)
        {
            var result = await _dbContext.Teams.FindAsync(id);

            if(result == null)
            {
                return null;
            }

            _dbContext.Teams.Remove(result);
            await _dbContext.SaveChangesAsync();
            return result;
        }
    }
}
