using System.ComponentModel.DataAnnotations;

namespace ShopsRCUS.Discount.API.Entities.DTOs
{
    public class InvoiceGenerateDTO
    {
        [Required]
        public Guid Id { get; set; }

        [Required]
        public IEnumerable<ProductCreationDTO> Products { get; set; }
    }

}
