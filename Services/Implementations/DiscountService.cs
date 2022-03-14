using AutoMapper;
using SelectPdf;
using ShopsRCUS.Discount.API.Entities.DTOs;
using ShopsRCUS.Discount.API.Entities.Models;
using ShopsRCUS.Discount.API.Entities.Settings;
using ShopsRCUS.Discount.API.Models;
using ShopsRCUS.Discount.API.Services.Interfaces;
using System.Text;

namespace ShopsRCUS.Discount.API.Services.Implementations
{
    public class DiscountService : IDiscountService
    {

        private readonly ILogger<DiscountService> _logger;
        private readonly IRepositoryService _repositoryService;
        private readonly IMapper _mapper;
        private readonly IWebHostEnvironment _env;
        public DiscountService(ILogger<DiscountService> logger,
                                IRepositoryService  repositoryService,
                                IMapper mapper,
                                IWebHostEnvironment env
                                )
        {
            _logger = logger;
            _repositoryService = repositoryService;
            _mapper = mapper;
            _env = env;

        }
        public IEnumerable<DiscountDTO> GetAllDiscount()
        {

            var discounts = _repositoryService.GetAllDiscount();
            var formatedResponse = _mapper.Map<IEnumerable<DiscountDTO>>(discounts);

            return formatedResponse;

        }

        public DiscountDTO GetDiscountByType(string type)
        {
            var discount = _repositoryService.GetDiscountByType(type);
            var formatedResponse = _mapper.Map<DiscountDTO>(discount);
            return formatedResponse;
        }


        public async Task<DiscountDTO> AddDiscount(DiscountCreationDTO newDiscount)
        { 
            var discountEntity = _mapper.Map<ShopsRCUS.Discount.API.Models.Discount>(newDiscount);

            var discount = await _repositoryService.AddDiscount(discountEntity);

            var formattedDiscount = _mapper.Map<DiscountDTO>(discount);
            return formattedDiscount;
            
        }

        public decimal GetEveryHundredDollarDiscount(decimal amount)
        {
            var percentage = GetAllNonCoupon().Where(x => x.Type.ToLower() == "everyhundreddollardiscount").FirstOrDefault().DiscountPercentage;

            var everyHunderedDollarResponse = IsEligibleForEveryHundredDollarDiscount(amount, percentage);
            if (everyHunderedDollarResponse.IsEligible)return everyHunderedDollarResponse.DiscountedPrice;

            return amount;
        }

        public IEnumerable<decimal> GetAllEligiblePercentageDiscountByCustomerBill(BillModel bill, string domain)
        {
            //Todo Get List of Discount form DB
            //Get Tax from appSetting
            //Get useleastDiscount flag
            decimal percentage;
            IList<decimal> customerEligibles = new List<decimal>();
            var productGroup = bill.products.GroupBy(x => x.IsGroceryType).ToList();

            var nonCouponDiscounts = GetAllNonCoupon();

            var isGroceriesSum = decimal.Zero;
            var isNotGroceries = new List<Product>();
            if (productGroup.Count == 1)
            {
                if (productGroup[0].Key)
                {
                    isGroceriesSum = productGroup[0].Sum(x => x.TotalPrice);
                }
                else
                {
                    isNotGroceries = productGroup[0].ToList();
                }
                
                
            }
            else if (productGroup.Count == 2)
            {
                foreach (var group in productGroup)
                {
                    if (group.Key)
                    {
                        isGroceriesSum = group.Sum(x => x.TotalPrice);
                    }
                    else
                    {
                        isNotGroceries = group.ToList();
                    }

                }
            }
           



            if (isNotGroceries.Count == 0)
            {
                return customerEligibles;
            }
                 percentage = nonCouponDiscounts.Where(x => x.Type.ToLower() == "employeediscount").FirstOrDefault().DiscountPercentage;

                
                var employeeDiscountResponse = IsEligibleForEmployeeDiscount(bill.Customer,isNotGroceries, percentage, domain);
                if (employeeDiscountResponse.IsEligible) customerEligibles.Add(employeeDiscountResponse.DiscountedPrice + isGroceriesSum);

                percentage = nonCouponDiscounts.Where(x => x.Type.ToLower() == "affiliatediscount").FirstOrDefault().DiscountPercentage;

                var affiliateDiscountResponse = IsEligibleForAffiliateDiscount(bill.Customer, isNotGroceries, percentage, domain);
            if (affiliateDiscountResponse.IsEligible) customerEligibles.Add(affiliateDiscountResponse.DiscountedPrice + isGroceriesSum);


            percentage = nonCouponDiscounts.Where(x => x.Type.ToLower() == "longtimecustomerdiscount").FirstOrDefault().DiscountPercentage;

                var longtimeDiscountResponse = IsEligibleForLongtimeCustomerDiscount(bill.Customer, isNotGroceries, percentage);
                if (longtimeDiscountResponse.IsEligible) customerEligibles.Add(longtimeDiscountResponse.DiscountedPrice + isGroceriesSum);
                return customerEligibles;
        }

        private productsDiscountModel IsEligibleForAffiliateDiscount(Customer customer, IEnumerable<Product> bill, decimal percentage, string domain)
        {
            productsDiscountModel isEligible = new productsDiscountModel();

            //Verify Employee From The GlobalEmployeeDataStore

            var employeeCheck = _repositoryService.GetEmployeeDetailsByEmail(customer.EmailAddress.ToLower());

            if (!(employeeCheck is object) || customer.EmailAddress.ToLower().Trim().EndsWith(domain.Trim().ToLower()))
            {
                return isEligible;
            }

            var s = customer.EmailAddress.Split(".")[0];//kolade@shopsrus.ng
            var k = domain.Split('.')[0]; //shopsrus.us

            if (!(s.ToLower().EndsWith(k)))
            {
                return isEligible;
            }
            isEligible.IsEligible = true;
            var productSum = bill.Sum(x => x.TotalPrice);
            var discountedBill = productSum - (productSum * (percentage / 100));

            isEligible.DiscountedPrice = discountedBill;

            return isEligible;

        }

        private productsDiscountModel IsEligibleForEmployeeDiscount(Customer customer, IEnumerable<Product> bill, decimal percentage, string domain)
        {
            productsDiscountModel isEligible = new productsDiscountModel();

            var employeeCheck = _repositoryService.GetEmployeeDetailsByEmail(customer.EmailAddress.ToLower());

            if (!(employeeCheck is object))
            {
                return isEligible;
            }

            if (!(customer.EmailAddress.Trim().ToLower().EndsWith(domain)))
            {
                return isEligible;
            }
            isEligible.IsEligible = true;
            var productSum = bill.Sum(x => x.TotalPrice);
            var discountedBill = productSum - (productSum * (percentage / 100));

            isEligible.DiscountedPrice = discountedBill;

            return isEligible;

        }

        private productsDiscountModel IsEligibleForLongtimeCustomerDiscount(Customer customer, IEnumerable<Product> bill,
            decimal percentage)
        {

            productsDiscountModel isEligible = new productsDiscountModel();

            TimeSpan span = DateTime.Now.Subtract(customer.CreatedAt);

            if (span.Days < 730)
            {
                return isEligible;
            }
            isEligible.IsEligible = true;
            var productSum = bill.Sum(x => x.TotalPrice);
            var discountedBill = productSum - (productSum *(percentage / 100));

            isEligible.DiscountedPrice = discountedBill;

            return isEligible;
        }

        private productsDiscountModel IsEligibleForEveryHundredDollarDiscount(decimal totalAmount, decimal discountAmount)
        {

            productsDiscountModel isEligible = new productsDiscountModel();

            if (totalAmount < 100)
            {
                return isEligible;
            }
            isEligible.IsEligible = true;
            var amountToDiscount = ((int)totalAmount / 100) * discountAmount;
            var discountedBill = totalAmount - amountToDiscount;

            isEligible.DiscountedPrice = discountedBill;

            return isEligible;
        }

        public IEnumerable<DiscountDTO>  GetAllNonCoupon()
        {
            var discounts = _repositoryService.GetAllNonCoupon();

           var formattedDiscount = _mapper.Map<IEnumerable<DiscountDTO>>(discounts);

            return formattedDiscount;
        }

        public decimal GetTotalBillAfterTax(decimal totalAmount, decimal vat)
        {
          //  var tax = decimal.Parse(_setting.Tax.ToString());
            var totalAfterTax = totalAmount +(totalAmount * (vat/100));

            return totalAfterTax;
        
        }

        public decimal GetDecidedDiscount(IEnumerable<decimal> possibleBillColl, bool decision)
        {
            if (decision)
            {
                return possibleBillColl.Min();
            }
            else
            { 
                return possibleBillColl.Max();
            }

        }

        public async Task<byte[]> GenerateInvoice(Guid invoiceId, BillModel bill, decimal totalAmountWithoutDiscount,
            decimal totalAmountWithDiscount,decimal discount, decimal tax, decimal amountPaid)
        {
            StringBuilder sb = new StringBuilder();
            HtmlToPdf pdf = new HtmlToPdf();
            string singleProduct = await System.IO.File.ReadAllTextAsync(_env.WebRootPath + @"\Views\productrow.html");
            string markSheet = string.Empty;
            markSheet = await System.IO.File.ReadAllTextAsync(_env.WebRootPath + @"\Views\invoice.html");

            var invoiceArray = markSheet.Split("{BODY}");

            sb.Append(invoiceArray[0]);

            foreach (var prod in bill.products)
            {
              
                var singleProdCopy = singleProduct;

                singleProdCopy = singleProdCopy.Replace("{productname}", prod.Name).Replace("{productprice}",
                    prod.UnitPrice.ToString("0.00")).Replace("{productdescription}", prod.Description)
                    .Replace("{quantity}", prod.Quantity.ToString()).Replace("{totalprice}", prod.TotalPrice.ToString("0.00"))
                    .Replace("{price}",prod.UnitPrice.ToString());
                sb.Append(singleProdCopy);

            }
            var invoiceString = sb.Append(invoiceArray[1]).ToString().Replace("{customername}", $"{bill.Customer.FirstName} {bill.Customer.LastName}")
                .Replace("{customeremail}", bill.Customer.EmailAddress).Replace("{invoiceid}", invoiceId.ToString())
                .Replace("{date}", (DateTime.Now).ToString()).Replace("{amount}", totalAmountWithoutDiscount.ToString("0.00"))
                .Replace("{tax}", tax.ToString()).Replace("{discount}", discount.ToString("0.00"))
                .Replace("{amountpaid}", amountPaid.ToString("0.00")).Replace("{balancedue}", totalAmountWithDiscount.ToString("0.00"));
            PdfDocument doc = pdf.ConvertHtmlString(invoiceString);
            var bytes = doc.Save();

            return bytes;

        }


        public void AddProducts()
        { 
            

        }
    }
}
