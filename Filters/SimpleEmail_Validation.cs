using System.ComponentModel.DataAnnotations;

namespace ShopsRCUS.Discount.API.Filters
{
    public class SimpleEmail_Validation : ValidationAttribute
    {
        protected override ValidationResult IsValid(object status, ValidationContext validationContext)
        {
            string Name = status as string;
            try
            {
                if (String.IsNullOrEmpty(Name)) return new ValidationResult(this.ErrorMessage);

                if (!Name.Trim().Contains("@") || !Name.Trim().Contains(".")) return new ValidationResult(this.ErrorMessage);



                return ValidationResult.Success;
            }
            catch (Exception ex)
            {
                return new ValidationResult(this.ErrorMessage);
            }

        }
    }

}