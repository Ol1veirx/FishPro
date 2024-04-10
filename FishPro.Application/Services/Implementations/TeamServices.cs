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
    public class TeamServices : ITeamServices
    {
        private readonly ITeamRepository _repository;
        private readonly IMapper _mapper;

        public TeamServices(ITeamRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<TeamDTO>> GetAllAsync()
        {
            var teams = await _repository.GetAllAsync();
            return _mapper.Map<IEnumerable<TeamDTO>>(teams);
        }

        public async Task<TeamDTO> GetByIdAsync(int id)
        {
            var team = await _repository.GetByIdAsync(id);
            return _mapper.Map<TeamDTO>(team);
        }

        public async Task<TeamDTO> CreateAsync(TeamDTO teamDTO)
        {
            var team = _mapper.Map<Team>(teamDTO);

            var newTeam = await _repository.CreateAsync(team);

            return _mapper.Map<TeamDTO>(newTeam);
        }

        public async Task<TeamDTO> UpdateAsync(TeamDTO teamDTO)
        {
            var team = _mapper.Map<Team>(teamDTO);

            var updateTeam = await _repository.UpdateAsync(team);

            return _mapper.Map<TeamDTO>(updateTeam);
        }

        public async Task<TeamDTO> DeleteAsync(int id)
        {
            var deleteTeam = await _repository.DeleteAsync(id);
            return _mapper.Map<TeamDTO>(deleteTeam);
        }
    }
}
