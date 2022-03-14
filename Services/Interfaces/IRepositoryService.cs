using ShopsRCUS.Discount.API.Entities.Models;
using ShopsRCUS.Discount.API.Models;

namespace ShopsRCUS.Discount.API.Services.Interfaces
{
    public interface IRepositoryService
    {
        public IEnumerable<Customer> GetAllCustomers(); 

        public Customer? GetCustomerById(Guid id);

        public Customer? GetCustomerByName(string Name);

        public Task<bool> AddCustomer(Customer customer);

        public bool SaveChanges();

        public IEnumerable<ShopsRCUS.Discount.API.Models.Discount> GetAllDiscount();

        public ShopsRCUS.Discount.API.Models.Discount GetDiscountByType(string type);

        public Task<ShopsRCUS.Discount.API.Models.Discount> AddDiscount(ShopsRCUS.Discount.API.Models.Discount discount);

        public IEnumerable<ShopsRCUS.Discount.API.Models.Discount> GetAllNonCoupon();

        public IEnumerable<ShopsRCUS.Discount.API.Models.Discount> GetAllCoupon();

        public GlobalEmployeeMock GetEmployeeDetailsByEmail(string email);

        public void AddInvoice(Invoice invoice);
    }
}
