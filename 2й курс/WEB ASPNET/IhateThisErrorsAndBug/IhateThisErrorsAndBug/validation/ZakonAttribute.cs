    using System.ComponentModel.DataAnnotations;

namespace IhateThisErrorsAndBug.validation
{
    public class ZakonAttribute : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value == null)
                return ValidationResult.Success;

            string text = value.ToString()!;

            foreach (char symbol in text)
            {
                if ((symbol >= 'A' && symbol <= 'Z') ||
                    (symbol >= 'a' && symbol <= 'z'))
                {
                    return new ValidationResult(
                        "Запрет англицизмов в названии(Федеральный закон от 24 июня 2025 г. №168-ФЗ) "
                    );
                }
            }

            return ValidationResult.Success;
        }
    }
}
