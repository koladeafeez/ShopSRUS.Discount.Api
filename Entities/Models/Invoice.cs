using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShopsRCUS.Discount.API.Models
{
    public class Invoice
    {
        [Key]
        public Guid Id { get; set; }

        [ForeignKey("Fk_Customer")]
        [Required]
        public Guid CustomerId { get; set; }

        [Required]
        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }

        public bool IsPaymentComplete { get; set; }

        public decimal PaymentBalance { get; set; }

        public decimal Discounts { get; set; }

        public decimal TotalAmount { get; set; }

        public decimal TotalAmountAfterDiscounts { get; set; }

        public IEnumerable<Product> Products { get; set; }
    }

    public class Product
    { 
        [Key]
        [Required]
        public Guid Id { get; set; }

        [Required]
        [ForeignKey("Fk_Invoice")]
        public Guid InvoiceId { get; set; }

        [Required]
        [MaxLength(50)]
        public string? Name { get; set; }

        [MaxLength(100)]
        public string? Description { get; set; }

        [Required]
        public int Quantity { get; set; }
        [Required]
        public decimal UnitPrice { get; set; }

        public decimal TotalPrice { get; set; }

        [Required]
        public bool IsGroceryType { get; set; }
        
    }
}
