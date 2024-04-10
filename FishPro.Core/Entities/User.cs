using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace FishPro.Core.Entities
{
    public class User 
    {
        public User(int id, string username, string email)
        {
            Id = id;
            Username = username;
            Email = email;
        }

        public User(string username, string email)
        {
            Username = username;
            Email = email;
        }

        public int Id {  get; private set; }
        public string Username { get; private set; }
        public string Email { get; private set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }

        public void ChangePassword(byte[] passwordHash, byte[] passwordSalt)
        {
            PasswordHash = passwordHash;
            PasswordSalt = passwordSalt;
        }
    }
}
