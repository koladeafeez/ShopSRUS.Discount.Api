using ShopsRCUS.Discount.API.Entities.DTOs;
using ShopsRCUS.Discount.API.Entities.Models;

namespace ShopsRCUS.Discount.API.Services.Interfaces
{
    public interface IDiscountService
    {
        public IEnumerable<DiscountDTO> GetAllDiscount();
        public DiscountDTO GetDiscountByType(string type);

        public Task<DiscountDTO> AddDiscount(DiscountCreationDTO newDiscount);
        public decimal GetTotalBillAfterTax(decimal totalAmount, decimal tax);
        public decimal GetDecidedDiscount(IEnumerable<decimal> possibleBillColl, bool decision);

        public IEnumerable<decimal> GetAllEligiblePercentageDiscountByCustomerBill(BillModel bill, string domain);

        public decimal GetEveryHundredDollarDiscount(decimal amount);

        public  Task<byte[]> GenerateInvoice(Guid invoiceId, BillModel bill, decimal totalAmount,
            decimal totalAmountAfterDiscount, decimal discount, decimal tax, decimal amountPaid);
    }
}
