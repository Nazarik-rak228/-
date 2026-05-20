using System.ComponentModel.DataAnnotations;

namespace IhateThisErrorsAndBug.validation
{
    public class NoOptBayingAttribute : ValidationAttribute
    {

        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value == null)
                return ValidationResult.Success;

            int quantity = (int)value;

            if (quantity > 10)
            {
                return new ValidationResult(
                    $"Нельзя заказать более 10 единиц товара"
                );
            }

            return ValidationResult.Success;
        }
    }
}
