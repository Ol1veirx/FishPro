using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FishPro.Core.Entities;

namespace FishPro.Infraestructure.Repositories.Interfaces
{
    public interface IResultRepository
    {
        Task<IEnumerable<Result>> GetAllAsync();
        Task<Result> GetByIdAsync(int id);
        Task<Result> CreateAsync(Result result);
        Task<Result> UpdateAsync(Result result);
        Task<Result> DeleteAsync(int id);
    }
}
