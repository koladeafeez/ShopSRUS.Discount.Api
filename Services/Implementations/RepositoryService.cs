using ShopsRCUS.Discount.API.Entities.DTOs;
using ShopsRCUS.Discount.API.Entities.Models;
using ShopsRCUS.Discount.API.Models;
using ShopsRCUS.Discount.API.Services.Interfaces; 

namespace ShopsRCUS.Discount.API.Services.Implementations
{
    public class RepositoryService : IRepositoryService
    {
        private readonly ShopsRUSDiscountDbContext _db;
        private readonly ILogger<RepositoryService> _logger;
        public RepositoryService(ShopsRUSDiscountDbContext dbContext, ILogger<RepositoryService> logger)
        { 
            _db = dbContext;
            _logger = logger;
        }

       public IEnumerable<Customer> GetAllCustomers()
        {
            IEnumerable<Customer> getCustomers = new List<Customer>();
            try
            {
                getCustomers = _db.Customers.ToList();
            }
            catch (Exception ex)
            {
                _logger.LogError("Exception Caught From Repository Service [GETALLCUSTOMERS]", ex.Message); 
            }
            return getCustomers;

        }

       public Customer? GetCustomerById(Guid id)
        {
            Customer? getCustomer = new Customer();

            try
            {
                if (id == Guid.Empty)
                {
                    throw new ArgumentNullException(nameof(id));
                }

                getCustomer = _db.Customers.Where(x => x.Id == id).SingleOrDefault();
            }
            catch (Exception ex)
            {
                _logger.LogError("Exception Caught From Repository Service [GETCUSTOMERBYID]", ex.Message);
            }

            return getCustomer;
        }

        public Customer? GetCustomerByName(string Name)
        {
            Customer? getCustomer = new Customer();

            try
            {
                if (String.IsNullOrEmpty(Name))
                {
                    throw new ArgumentNullException(nameof(Name));
                }

                getCustomer = _db.Customers.Where(x => x.EmailAddress.ToLower() == Name).SingleOrDefault();
            }
            catch (Exception ex)
            {
                _logger.LogError("Exception Caught From Repository Service [GETCUSTOMERBYNAME]", ex.Message);
            }

            return getCustomer;
        }

        public async Task<bool> AddCustomer(Customer customer)
        {
            Customer? getCustomer = new Customer();

            try
            {
                if (!(customer is object))
                {
                    throw new ArgumentNullException(nameof(customer));
                }

                customer.Id = Guid.NewGuid();

               await _db.Customers.AddAsync(customer);
                return true;

            }
            catch (Exception ex)
            {
                _logger.LogError("Exception Caught From Repository Service [ADDCUSTOMER]", ex.Message);
                return false;
            }

        }

        public bool SaveChanges()
        {
            return (_db.SaveChanges() >= 0);
        }

        public IEnumerable<ShopsRCUS.Discount.API.Models.Discount> GetAllDiscount()
        {

            IEnumerable<ShopsRCUS.Discount.API.Models.Discount> getDiscounts = new List<ShopsRCUS.Discount.API.Models.Discount>();

            try
            {

                getDiscounts = _db.Discounts.ToList();
            }
            catch (Exception ex)
            {
                _logger.LogError("Exception Caught From Repository Service [GETALLDISCOUNT", ex.Message);
            }

           return getDiscounts;

        }

        public ShopsRCUS.Discount.API.Models.Discount GetDiscountByType(string type)
        {
            ShopsRCUS.Discount.API.Models.Discount getDiscount = new ShopsRCUS.Discount.API.Models.Discount();

            try
            {

                getDiscount = _db.Discounts.Where(x => x.Type.ToLower() == type).FirstOrDefault();
            }
            catch (Exception ex)
            {
                _logger.LogError("Exception Caught From Repository Service [GETDISCOUNTBYTYPE", ex.Message);
            }

            return getDiscount;
        }


        public async Task<ShopsRCUS.Discount.API.Models.Discount> AddDiscount(ShopsRCUS.Discount.API.Models.Discount discount)
        {

            try
            {
                if (!(discount is object))
                {
                    throw new ArgumentNullException(nameof(discount));
                }

                discount .Id = Guid.NewGuid();
                discount.IsCouponType = true;


                await _db.Discounts.AddAsync(discount);

            }
            catch (Exception ex)
            {
                _logger.LogError("Exception Caught From Repository Service [ADDDISCOUNT]", ex.Message);
            }

            return discount;

        }

        public IEnumerable<ShopsRCUS.Discount.API.Models.Discount> GetAllNonCoupon()
        {
            IEnumerable<ShopsRCUS.Discount.API.Models.Discount> discounts = new List<ShopsRCUS.Discount.API.Models.Discount>();
            try
            {

               discounts =  _db.Discounts.Where(x => !x.IsCouponType).ToList();

            }
            catch (Exception ex)
            {
                _logger.LogError("Exception Caught From Repository Service [ADDDISCOUNT]", ex.Message);
            }

            return discounts;

        }


        public IEnumerable<ShopsRCUS.Discount.API.Models.Discount> GetAllCoupon()
        {
            IEnumerable<ShopsRCUS.Discount.API.Models.Discount> discounts = new List<ShopsRCUS.Discount.API.Models.Discount>();
            try
            {

                discounts = _db.Discounts.Where(x => x.IsCouponType).ToList();

            }
            catch (Exception ex)
            {
                _logger.LogError("Exception Caught From Repository Service [ADDDISCOUNT]", ex.Message);
            }

            return discounts;

        }

        public GlobalEmployeeMock GetEmployeeDetailsByEmail(string email)
        {
            GlobalEmployeeMock employee = new GlobalEmployeeMock();
            try
            {

               employee = _db.globalEmployeeMocks.Where(x => x.Email.ToLower() == email).FirstOrDefault();

            }
            catch (Exception ex)
            {
                _logger.LogError("Exception Caught From Repository Service [GETEMPLOYEEDETAILSByEMAIL]", ex.Message);
            }

            return employee;

        }

        public async void AddInvoice(Invoice invoice)
        {
            try
            {

                await _db.Invoices.AddAsync(invoice);

            }
            catch (Exception ex)
            {
                _logger.LogError("Exception Caught From Repository Service [AddInvoice]", ex.Message);
            }

        }

    }
    }
