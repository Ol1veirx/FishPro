using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using FishPro.Application.Services.DTO;
using FishPro.Application.Services.Interfaces;
using FishPro.Core.Entities;
using FishPro.Infraestructure.Repositories.Interfaces;

namespace FishPro.Application.Services.Implementations
{
    public class UserServices : IUserServices
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        public UserServices(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<UserDTO>> GetAllUsers()
        {
            var users = await _userRepository.GetAllUsers();
            return _mapper.Map<IEnumerable<UserDTO>>(users);
        }

        public async Task<UserDTO> GetUserById(int userId)
        {
            var user = await _userRepository.GetUserById(userId);
            return _mapper.Map<UserDTO>(user);
        }

        public async Task<UserDTO> CreateUserAsync(UserDTO userDTO)
        {
            var user = _mapper.Map<User>(userDTO);

            byte[] passwordHash, passwordSalt;
            CreatePasswordHash(userDTO.Password, out passwordHash, out passwordSalt);

            user.ChangePassword(passwordHash, passwordSalt);

            var newUser = await _userRepository.CreateUserAsync(user);

            return _mapper.Map<UserDTO>(newUser);
        }

        public async Task<UserDTO> UpdateUserAsync(UserDTO userDTO)
        {
            var user = _mapper.Map<User>(userDTO);
            var updateUser = await _userRepository.UpdateUserAsync(user);
            return _mapper.Map<UserDTO>(updateUser);
        }

        public async Task<UserDTO> DeleteUserAsync(int userId)
        {
            var result = await _userRepository.DeleteUserAsync(userId);
            return _mapper.Map<UserDTO>(result);
        }

        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
            }
        }
    }
}
