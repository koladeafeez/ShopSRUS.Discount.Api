using System.ComponentModel.DataAnnotations;

namespace ShopsRCUS.Discount.API.Filters
{
    public class NameFormat_Validation : ValidationAttribute
    {

        protected override ValidationResult IsValid(object status, ValidationContext validationContext)
        {
            string Name = status as string;
            try
            {
                if (String.IsNullOrEmpty(Name)) return new ValidationResult(this.ErrorMessage);

                if(Name.Trim().Split(" ").Length != 2) return new ValidationResult(this.ErrorMessage);

                var firstName = Name.Trim().Substring(0, Name.Trim().IndexOf(" "));
                var lastName = Name.Trim().Substring(Name.Trim().LastIndexOf(" ")) + 1;

                if (string.IsNullOrEmpty(firstName) || string.IsNullOrEmpty(lastName))
                {
                    return new ValidationResult(this.ErrorMessage);
                }


                return ValidationResult.Success;
            }
            catch (Exception ex)
            {
                return new ValidationResult(this.ErrorMessage);
            }

        }
    }

 

}

