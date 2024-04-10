using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FishPro.Application.Services.DTO
{
    public class UserDTO
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "O nome é obrigatório")]
        [MaxLength(250, ErrorMessage = "O username não pode ter mais de 250 caracteres")]
        public string Username { get; set; }

        [Required(ErrorMessage = "O email é obrigatório")]
        [MaxLength(250, ErrorMessage = "O email não pode ter mais de 250 caracteres")]
        public string Email { get; set; }

        [Required(ErrorMessage = "A senha é obrigatório")]
        [MaxLength(250, ErrorMessage = "A senha não pode ter mais de 250 caracteres")]
        [MinLength(6, ErrorMessage = "A senha deve ter, no mínimo, 6 caracteres")]
        [NotMapped]
        public string Password { get; set; }
    }
}
