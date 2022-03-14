namespace ShopsRCUS.Discount.API.Entities.DTOs
{
    public class ProductDTO
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public bool IsGroceryType { get; set; }


    }
}
