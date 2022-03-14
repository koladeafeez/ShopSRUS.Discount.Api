using System.ComponentModel.DataAnnotations;

namespace ShopsRCUS.Discount.API.Entities.Models
{
    public class GlobalEmployeeMock
    {
        [Required]
        public Guid Id { get; set; } = Guid.NewGuid();
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public DateTime DateOfBirth { get; set; }

        [EmailAddress]
        [Required]
        public string Email { get; set; }
        
        [Required]
        [MaxLength(7)]
        public string LocationCode { get; set; }

        [Required]
        public string LocationCoverageName { get; set; }


    }
}
