using System.ComponentModel.DataAnnotations;

namespace FishPro.API.Models
{
    public class LoginModel
    {
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
