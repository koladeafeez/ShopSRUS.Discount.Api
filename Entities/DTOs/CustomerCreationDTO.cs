using ShopsRCUS.Discount.API.Filters;
using System.ComponentModel.DataAnnotations;

namespace ShopsRCUS.Discount.API.Entities.DTOs
{
    public class CustomerCreationDTO
    {

        [Required]
        [NameFormat_Validation(ErrorMessage ="Invalid Name Field,Accepted Format Is [FirstName LastName]")]
        public string? Name { get; set; }

        [Required]
        public string? Address { get; set; }

        [Required]
        [EmailAddress]
        [SimpleEmail_Validation(ErrorMessage = "Email Not A Valid Email Address")]

        public string? EmailAddress { get; set; }

        [Required]
        public string? Password { get; set; }
    }
}
