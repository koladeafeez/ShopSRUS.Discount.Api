using System.ComponentModel.DataAnnotations;

namespace ShopsRCUS.Discount.API.Entities.DTOs
{
    public class ProductCreationDTO
    {
        [Required]
        [StringLength(30)]
        public string? Name { get; set; }
        [Required]
        [StringLength(50)]
        public string? Description { get; set; }
        [Required]
        public int Quantity { get; set; }
        [Required]
        public decimal Price { get; set; }
        [Required]
        public bool IsGroceryType { get; set; }

    }
}
