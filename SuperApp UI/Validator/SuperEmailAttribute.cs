using System.ComponentModel.DataAnnotations;

namespace SuperApp_UI.Validator
{
    public class SuperEmailAttribute : ValidationAttribute
    {
        public SuperEmailAttribute()
        {
            ErrorMessage = "Email must end with @super.com";
        }

        public override bool IsValid(object? value)
        {
            if (value == null) return false;

            var email = value.ToString();
            return email.EndsWith("@super.com",StringComparison.OrdinalIgnoreCase);
        }
    }
}
