using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FishPro.Application.Services.DTO;

namespace FishPro.Application.Services.Interfaces
{
    public interface IResultServices
    {
        Task<IEnumerable<ResultDTO>> GetAllAsync();
        Task<ResultDTO> GetByIdAsync(int id);
        Task<ResultDTO> CreateAsync(ResultDTO resultDTO);
        Task<ResultDTO> UpdateAsync(ResultDTO resultDTO);
        Task<ResultDTO> DeleteAsync(int id);
    }
}
