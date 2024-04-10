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
    public class StageServices : IStageServices
    {
        private readonly IStageRepository _stageRepository;
        private readonly IMapper _mapper;

        public StageServices(IStageRepository stageRepository, IMapper mapper)
        {
            _stageRepository = stageRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<StageDTO>> GetAllAsync()
        {
            var stages = await _stageRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<StageDTO>>(stages);
        }

        public async Task<StageDTO> GetByIdAsync(int id)
        {
            var stage = await _stageRepository.GetByIdAsync(id);
            return _mapper.Map<StageDTO>(stage);   
        }
        public async Task<StageDTO> CreateAsync(StageDTO stageDTO)
        {
            var stage = _mapper.Map<Stage>(stageDTO);

            var newStage = await _stageRepository.CreateAsync(stage);

            return _mapper.Map<StageDTO>(newStage);
        }

        public async Task<StageDTO> UpdateAsync(StageDTO stageDTO)
        {
            var stage = _mapper.Map<Stage>(stageDTO);

            var updateStage = await _stageRepository.UpdateAsync(stage);

            return _mapper.Map<StageDTO>(updateStage);
        }

        public async Task<StageDTO> DeleteAsync(int id)
        {
            var deleteStage = await _stageRepository.DeleteAsync(id);
            return _mapper.Map<StageDTO>(deleteStage);
        }
    }
}
