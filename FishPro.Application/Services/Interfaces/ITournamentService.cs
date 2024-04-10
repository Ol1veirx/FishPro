using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FishPro.Application.Services.DTO;
using FishPro.Core.Entities;

namespace FishPro.Application.Services.Interfaces
{
    public interface ITournamentService
    {
        Task<IEnumerable<TournamentDTO>> GetAllAsync();
        Task<TournamentDTO> GetByIdAsync(int id);
        Task<TournamentDTO> CreateAsync(TournamentDTO TournamentDTO);
        Task<TournamentDTO> UpdateAsync(TournamentDTO TournamentDTO);
        Task<TournamentDTO> DeleteAsync(int id);
    }
}

