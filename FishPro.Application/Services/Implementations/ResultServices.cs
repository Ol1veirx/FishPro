using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using FishPro.Application.Services.DTO;
using FishPro.Application.Services.Interfaces;
using FishPro.Core.Entities;
using FishPro.Infraestructure.Repositories.Interfaces;

namespace FishPro.Application.Services.Implementations
{
    public class ResultServices : IResultServices
    {
        private readonly IResultRepository _resultRepository;
        private readonly IMapper _mapper;

        public ResultServices(IResultRepository resultRepository, IMapper mapper)
        {
            _resultRepository = resultRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ResultDTO>> GetAllAsync()
        {
            var results = await _resultRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<ResultDTO>>(results);    
        }

        public async Task<ResultDTO> GetByIdAsync(int id)
        {
            var result = await _resultRepository.GetByIdAsync(id);
            return _mapper.Map<ResultDTO>(result);
        }

        public async Task<ResultDTO> CreateAsync(ResultDTO resultDTO)
        {
            var result = _mapper.Map<Result>(resultDTO);

            var newResult = await _resultRepository.CreateAsync(result);

            return _mapper.Map<ResultDTO>(newResult);
        }

        public async Task<ResultDTO> UpdateAsync(ResultDTO resultDTO)
        {
            var result = _mapper.Map<Result>(resultDTO);

            var updateResult = await _resultRepository.UpdateAsync(result);

            return _mapper.Map<ResultDTO>(updateResult);
        }

        public async Task<ResultDTO> DeleteAsync(int id)
        {
            var deleteResult = await _resultRepository.DeleteAsync(id);
            return _mapper.Map<ResultDTO>(deleteResult);
        }

    }
}
