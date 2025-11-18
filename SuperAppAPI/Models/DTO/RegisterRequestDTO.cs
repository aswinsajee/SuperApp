using System.ComponentModel.DataAnnotations;

namespace SuperAppAPI.Models.DTO
{
    public class RegisterRequestDTO
    {
        [Required]
        [DataType(DataType.EmailAddress)]
        public string UserName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required]
        public string PhoneNumber { get; set; }

        public string[] Roles { get; set; }
    }
}
