using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FishPro.Application.Services.DTO;
using FishPro.Core.Entities;

namespace FishPro.Application.Services.Interfaces
{
    public interface IUserServices
    {
        Task<IEnumerable<UserDTO>> GetAllUsers();
        Task<UserDTO> GetUserById(int userId);
        Task<UserDTO> CreateUserAsync(UserDTO user);
        Task<UserDTO> UpdateUserAsync(UserDTO user);
        Task<UserDTO> DeleteUserAsync(int userId);
    }
}
