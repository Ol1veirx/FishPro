using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FishPro.Core.Entities;

namespace FishPro.Infraestructure.Repositories.Interfaces
{
    public interface ITeamRepository
    {
        Task<IEnumerable<Team>> GetAllAsync();
        Task<Team> GetByIdAsync(int id);
        Task<Team> CreateAsync(Team team);
        Task<Team> UpdateAsync(Team team);
        Task<Team> DeleteAsync(int id);
    }
}
