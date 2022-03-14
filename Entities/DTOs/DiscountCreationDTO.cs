using System.ComponentModel.DataAnnotations;

namespace ShopsRCUS.Discount.API.Entities.DTOs
{
    public class DiscountCreationDTO
    {
        [Required]
        public string? Type { get; set; }

        [Required]
        public string? Description { get; set; }

        [Range(1, 101)]
        [Required]
        public Decimal DiscountPercentage { get; set; }

        public DateTime ValidUntill { get; set; }
       
    }
}
