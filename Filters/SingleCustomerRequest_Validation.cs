/*using System.ComponentModel.DataAnnotations;

namespace ShopsRCUS.Discount.API.Filters
{
    public class SingleCustomerRequest_Validation : ValidationAttribute
    {
        protected override ValidationResult IsValid(object param, ValidationContext validationContext)
        {
            Guid response = Guid.Empty;
            Guid.TryParse(param.ToString(), out response);
            if(response == Guid.Empty)
            {
                return new ValidationResult(this.ErrorMessage);
            }
        }
    }
}*/
