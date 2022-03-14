namespace ShopsRCUS.Discount.API.Entities.DTOs
{
    public class DiscountDTO
    {
        public Guid Id { get; set; }

        public string? Type { get; set; }

        public string? Description { get; set; }

        public decimal DiscountPercentage { get; set; }

        public DateTime ValidUntill { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public DateTime UpdatedAt { get; set; } = DateTime.Now;

    }
}
