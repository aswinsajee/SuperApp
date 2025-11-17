using SuperApp_UI.Validator;
using System.ComponentModel.DataAnnotations;

namespace SuperApp_UI.Models
{
    public class RegisterRequestDTO
    {
        
        [SuperEmail]
        public string UserName { get; set; }

        
        
        public string Password { get; set; }


        
        public string PhoneNumber { get; set; }
        public List<string>? Roles { get; set; }
    }
}
