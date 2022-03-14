using System.ComponentModel.DataAnnotations;

namespace ShopsRCUS.Discount.API.Models
{
    public class Customer
    {
        [Key]
        [Required]
        public Guid Id { get; set; }

        [Required]
        public string? FirstName { get; set; }
        public string? LastName { get; set;}

        [Required]
        public string? Address { get; set; }

        [Required]
        [EmailAddress]
        public string? EmailAddress { get; set; }

        [Required]
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public DateTime? UpdatedAt { get; set; } 

        [Required]
        public string? PasswordHashed { get; set; }

    }
}
