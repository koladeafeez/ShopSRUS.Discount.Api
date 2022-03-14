using System.ComponentModel.DataAnnotations;

namespace ShopsRCUS.Discount.API.Models
{
    public class Coupon
    {
        [Key]
        [Required]
        public Guid Id { get; set; }
        [Required]
        public string? Type { get; set; }

        public string? Description { get; set; }

        [Range(1,101)]
        [Required]
        public Decimal DiscountPercentage { get; set; }

        public DateTime ValidUntill { get; set; }
        [Required]
        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }
    }
}
