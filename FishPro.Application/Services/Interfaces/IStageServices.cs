using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FishPro.Application.Services.DTO;
using FishPro.Core.Entities;

namespace FishPro.Application.Services.Interfaces
{
    public interface IStageServices 
    {
        Task<IEnumerable<StageDTO>> GetAllAsync();
        Task<StageDTO> GetByIdAsync(int id);
        Task<StageDTO> CreateAsync(StageDTO stageDTO);
        Task<StageDTO> UpdateAsync(StageDTO stageDTO);
        Task<StageDTO> DeleteAsync(int id);
    }
}
