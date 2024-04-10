using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FishPro.Core.Entities;

namespace FishPro.Infraestructure.Repositories.Interfaces
{
    public interface ITournamentRepository
    {
        Task<IEnumerable<Tournament>> GetAllAsync();
        Task<Tournament> GetByIdAsync(int id);
        Task<Tournament> CreateAsync(Tournament tournament);
        Task<Tournament> UpdateAsync(Tournament tournament);
        Task<Tournament> DeleteAsync(int id);
    }
}
