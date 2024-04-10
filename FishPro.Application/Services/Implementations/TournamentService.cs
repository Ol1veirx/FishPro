using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using FishPro.Application.Services.DTO;
using FishPro.Application.Services.Interfaces;
using FishPro.Core.Entities;
using FishPro.Infraestructure.Repositories.Interfaces;

namespace FishPro.Application.Services.Implementations
{
    public class TournamentService : ITournamentService
    {
        private readonly ITournamentRepository _tournamentRepository;
        private readonly IMapper _mapper;

        public TournamentService(ITournamentRepository tournamentRepository, IMapper mapper)
        {
            _tournamentRepository = tournamentRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<TournamentDTO>> GetAllAsync()
        {
            var tournaments = await _tournamentRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<TournamentDTO>>(tournaments);
        }

        public async Task<TournamentDTO> GetByIdAsync(int id)
        {
            var tournament = await _tournamentRepository.GetByIdAsync(id);
            return _mapper.Map<TournamentDTO>(tournament);
        }
        public async Task<TournamentDTO> CreateAsync(TournamentDTO tournamentDTO)
        {
            var tournament = _mapper.Map<Tournament>(tournamentDTO);

            var newTournament = await _tournamentRepository.CreateAsync(tournament);

            return _mapper.Map<TournamentDTO>(newTournament);
            
        }

        public async Task<TournamentDTO> UpdateAsync(TournamentDTO tournamentDTO)
        {
            var tournament = _mapper.Map<Tournament>(tournamentDTO);

            var updateTournament = await _tournamentRepository.UpdateAsync(tournament);

            return _mapper.Map<TournamentDTO>(updateTournament);
        }

        public async Task<TournamentDTO> DeleteAsync(int id)
        {
            var deleteTournament = await _tournamentRepository.DeleteAsync(id);
            return _mapper.Map<TournamentDTO>(deleteTournament);
        }
    }
}
