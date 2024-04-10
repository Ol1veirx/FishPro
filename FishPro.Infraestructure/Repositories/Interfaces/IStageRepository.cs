using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FishPro.Core.Entities;

namespace FishPro.Infraestructure.Repositories.Interfaces
{
    public interface IStageRepository
    {
        Task<IEnumerable<Stage>> GetAllAsync();
        Task<Stage> GetByIdAsync(int id);
        Task<Stage> CreateAsync(Stage stage);
        Task<Stage> UpdateAsync(Stage stage);
        Task<Stage> DeleteAsync(int id);
    }
}
