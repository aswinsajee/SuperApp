using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace SuperAppUI.Validator
{
    public class SuperMobileAttribute : ValidationAttribute
    {
        public SuperMobileAttribute()
        {
            ErrorMessage = "Invalid mobile number. Must be 10 digits starting with 6-9.";
        }

        public override bool IsValid(object? value)
        {
            if (value == null) return false;

            var mobile = value.ToString()!.Trim();

            return Regex.IsMatch(mobile, @"^[6-9]\d{9}$");
        }
    }
}
