using System.ComponentModel.DataAnnotations;

namespace SuperApp_UI.Models
{
    public class LoginDTO
    {
        [Required(ErrorMessage = "Email is required.")]
        [DataType(DataType.EmailAddress)]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Password is required.")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        public string? Token { get; set; }
    }
}
