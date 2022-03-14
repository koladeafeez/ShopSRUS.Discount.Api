using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewEngines;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using SelectPdf;
using ShopsRCUS.Discount.API.Entities.DTOs;
using ShopsRCUS.Discount.API.Entities.Models;
using ShopsRCUS.Discount.API.Entities.Settings;
using ShopsRCUS.Discount.API.Models;
using ShopsRCUS.Discount.API.Services.Interfaces;
using System.Text;

namespace ShopsRCUS.Discount.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InvoiceController : ControllerBase
    {
    
        private readonly IRepositoryService _repositoryService;
        private readonly IMapper _mapper;
        private readonly IDiscountService _discountService;
        private readonly DiscountSetting _setting;
        public InvoiceController(
                    IWebHostEnvironment env,
                    IRepositoryService repositoryService,
                    IMapper mapper,
                    IDiscountService discountService,
                    DiscountSetting setting
                   )
        { 
            _repositoryService = repositoryService;
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _discountService = discountService ?? throw new ArgumentNullException(nameof(discountService));
            _setting = setting ?? throw new ArgumentNullException(nameof(setting));
        }

        [HttpPost]
        public async Task<IActionResult> GenerateInvoice(InvoiceGenerateDTO bill)
        {
            BillModel billRequest = new BillModel(); 
            var getCustomer = _repositoryService.GetCustomerById(bill.Id);

            // return NotFound If Null
            if (!(getCustomer is object))
            {
                return NotFound();
            }

            // Map DTO to Entity and Transform totalPrice
            billRequest.Customer = getCustomer;
            var productEntity = _mapper.Map<IEnumerable<Product>>(bill.Products);
            billRequest.products = productEntity;

            // Get All Eligible Possible TotalPrice By Percentage Discount
            //Return Collection Of All Possible Bill
            var domain = _setting.domain;
           // var domain = "shoprcus.com";
           var customerDiscountsColl =  _discountService.GetAllEligiblePercentageDiscountByCustomerBill(billRequest, domain);

            // Return the Decided Bill Base On Config Setting
            var decision = _setting.UseLowestDiscount;
            var getDecidedDiscount = (customerDiscountsColl.Count() == 0)
                ? productEntity.Sum(x => x.TotalPrice): _discountService.GetDecidedDiscount(customerDiscountsColl, decision);

            // Check If Bill Is Eligible For EveryDollar Discount, Deduct Calculated Amount If Eligible
            var amountAfterEveryHundred = _discountService.GetEveryHundredDollarDiscount(getDecidedDiscount);

            // Add AddTax
            var tax = decimal.Parse(_setting.Tax);
            var totalBill = _discountService.GetTotalBillAfterTax(amountAfterEveryHundred, tax);

            var totalAmountWithoutDiscount = productEntity.Sum(x => x.TotalPrice) + tax;
            
            byte[] invoice = await _discountService.GenerateInvoice(bill.Id,billRequest,totalAmountWithoutDiscount,totalBill,
                                totalAmountWithoutDiscount - totalBill,tax,0);


            var inv = new Invoice
            {
                CreatedAt = DateTime.Now,
                CustomerId = billRequest.Customer.Id,
                Discounts = totalAmountWithoutDiscount - totalBill,
                Id = Guid.NewGuid(),
                IsPaymentComplete = false,
                PaymentBalance = totalBill,
                TotalAmount = totalBill,
                UpdatedAt = DateTime.Now,
                TotalAmountAfterDiscounts = totalAmountWithoutDiscount,
                Products = productEntity
            };


            _repositoryService.AddInvoice(inv);
            _repositoryService.SaveChanges();

           return File(invoice, "application/pdf", $"{billRequest.Customer.FirstName+billRequest.Customer.LastName}_Invoice.pdf");

        }

        

    }
}
