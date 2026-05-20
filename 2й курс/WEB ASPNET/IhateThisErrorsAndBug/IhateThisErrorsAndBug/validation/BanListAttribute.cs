using IhateThisErrorsAndBug.Models;
using System.ComponentModel.DataAnnotations;

namespace IhateThisErrorsAndBug.validation
{
    public class BanListAttribute : ValidationAttribute

    {
       
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value == null)
            {
                return ValidationResult.Success;
            }
            string word = value.ToString().ToLower();
            string[] banlist = ["гитлер", "хитлер", "негр", "неггр", "нигга", "нига", "", "чмо", "ублюдок"];

            if (banlist.Contains(word))
            {
                    return new ValidationResult("Это слово запрещено");

            }
            return ValidationResult.Success;
        }
    }
}
