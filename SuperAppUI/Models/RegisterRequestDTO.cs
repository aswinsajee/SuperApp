using SuperAppUI.Validator;
using System.ComponentModel.DataAnnotations;

namespace SuperAppUI.Models
{
    public class RegisterRequestDTO
    {
        
        [SuperEmail]
        public string UserName { get; set; }


        [SuperPassword]
        public string Password { get; set; }


        [SuperMobile]
        public string PhoneNumber { get; set; }
        public List<string>? Roles { get; set; }
    }
}
