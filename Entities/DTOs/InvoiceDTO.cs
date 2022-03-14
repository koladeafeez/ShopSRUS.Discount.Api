using System.ComponentModel.DataAnnotations;

namespace ShopsRCUS.Discount.API.Entities.DTOs
{
    public class InvoiceDTO
    {
        [Required]
        public Guid Id { get; set; }

        [Required]
        public IEnumerable<ProductDTO> Products { get; set; }
    }

    
}
