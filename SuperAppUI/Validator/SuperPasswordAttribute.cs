using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace SuperAppUI.Validator
{
    public class SuperPasswordAttribute : ValidationAttribute
    {
        public SuperPasswordAttribute()
        {
            ErrorMessage = "Password must contain upper, lower, digit, special character and be at least 8 characters long.";
        }

        public override bool IsValid(object? value)
        {
            if (value == null) return false;

            var password = value.ToString()!;

            if (password.Length < 8)
                return false;

            bool hasUpper = Regex.IsMatch(password, "[A-Z]");
            bool hasLower = Regex.IsMatch(password, "[a-z]");
            bool hasDigit = Regex.IsMatch(password, "[0-9]");
            bool hasSpecial = Regex.IsMatch(password, "[^a-zA-Z0-9]");

            return hasUpper && hasLower && hasDigit && hasSpecial;
        }
    }
}
