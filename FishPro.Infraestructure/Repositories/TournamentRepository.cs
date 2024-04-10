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
    public class TournamentRepository : ITournamentRepository
    {
        private readonly FpDbContext _dbContext;
        public TournamentRepository(FpDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Tournament>> GetAllAsync()
        {
            return await _dbContext.Tournaments.Include(t => t.Teams).AsNoTracking().ToListAsync();
        }

        public async Task<Tournament> GetByIdAsync(int id)
        {
            var tournament = await _dbContext.Tournaments.SingleOrDefaultAsync(t => t.Id == id);

            if(tournament == null)
            {
                return null;
            }

            return tournament;
        }

        public async Task<Tournament> CreateAsync(Tournament tournament)
        {
            _dbContext.Tournaments.Add(tournament);
            await _dbContext.SaveChangesAsync();
            return tournament;
        }

        public async Task<Tournament> UpdateAsync(Tournament tournament)
        {
            _dbContext.Tournaments.Update(tournament);
            await _dbContext.SaveChangesAsync();
            return tournament;
        }

        public async Task<Tournament> DeleteAsync(int id)
        {
            var result = await _dbContext.Tournaments.FindAsync(id);

            if (result == null)
            {
                return null;
            }

            _dbContext.Tournaments.Remove(result);
            await _dbContext.SaveChangesAsync();

            return result;
        }

    }
}
