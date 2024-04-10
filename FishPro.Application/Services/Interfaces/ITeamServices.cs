using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FishPro.Application.Services.DTO;
using FishPro.Core.Entities;

namespace FishPro.Application.Services.Interfaces
{
    public interface ITeamServices
    {
        Task<IEnumerable<TeamDTO>> GetAllAsync();
        Task<TeamDTO> GetByIdAsync(int id);
        Task<TeamDTO> CreateAsync(TeamDTO teamDTO);
        Task<TeamDTO> UpdateAsync(TeamDTO teamDTO);
        Task<TeamDTO> DeleteAsync(int id);
    }
}
