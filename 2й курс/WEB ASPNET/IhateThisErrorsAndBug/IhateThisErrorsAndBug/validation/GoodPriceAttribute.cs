using System.ComponentModel.DataAnnotations;

namespace IhateThisErrorsAndBug.validation
{
    public class GoodPriceAttribute : ValidationAttribute
    {

        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value == null)
                return ValidationResult.Success;

            decimal price = (decimal)value;

            decimal fractionalPart = price % 1;

            if (fractionalPart is not (decimal)0.90 and
                not (decimal)0.99)
            {
                return new ValidationResult(
                    "Цена должна заканчиваться на ,90 или ,99"
                );
            }


            return ValidationResult.Success;
        }
    }
}
