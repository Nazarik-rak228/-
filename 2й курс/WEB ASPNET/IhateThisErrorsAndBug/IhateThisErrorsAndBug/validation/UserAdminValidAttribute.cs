using IhateThisErrorsAndBug.Models;
using System.ComponentModel.DataAnnotations;

namespace IhateThisErrorsAndBug.validation
    
{
    public class UserAdminValidAttribute : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if( value == null)
            {
                return ValidationResult.Success;
            }
            var user = (User)validationContext.ObjectInstance;

            if (user.RoleId == 1)
            {
                string name = value.ToString();
                if(name != "Царь")
                return new ValidationResult("Админом может быть только Царь");

            }
            return ValidationResult.Success;
        }
    }
}
