using ShopsRCUS.Discount.API.Models;

namespace ShopsRCUS.Discount.API.Entities.Models
{
    public class BillModel
    {
        public Customer Customer { get; set; }
        public IEnumerable<Product> products { get; set; } = new List<Product>();
    }
}
