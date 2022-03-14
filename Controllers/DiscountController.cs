using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShopsRCUS.Discount.API.Entities.DTOs;
using ShopsRCUS.Discount.API.Entities.Settings;
using ShopsRCUS.Discount.API.Services.Interfaces;

namespace ShopsRCUS.Discount.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DiscountsController : ControllerBase
    {

        private readonly IRepositoryService _repositoryService;
        private readonly IMapper _mapper;
        private readonly IDiscountService _discountService;
        //private readonly DiscountSetting _setting;

        public DiscountsController(IRepositoryService repositoryService,
                                   IMapper mapper,
                                   IDiscountService discountService
                                   //DiscountSetting setting
                                   )
        {
            _repositoryService = repositoryService ?? throw new ArgumentNullException(nameof(repositoryService));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _discountService = discountService ?? throw new ArgumentNullException(nameof(discountService));
            // _setting = setting ?? throw new ArgumentNullException(nameof(setting));

        }

        [HttpGet]
        [Produces("application/json","application/xml", Type = typeof(IEnumerable<DiscountDTO>))]
        public ActionResult<IEnumerable<DiscountDTO>> GetAllDiscount()
        {
            var discounts = _discountService.GetAllDiscount();

            return Ok(discounts);
        }

        [HttpGet("{type}", Name = "GetDiscountByType")]
        [Produces("application/json", "application/xml", Type = typeof(DiscountDTO))]
        public ActionResult<DiscountDTO> GetDiscount(string type)
        {
            var discount = _discountService.GetDiscountByType(type);

            if (!(discount is object))
            {
                return NotFound();
            }
            return Ok(discount);
        }

        [HttpPost]
        [Produces("application/json", "application/xml", Type = typeof(DiscountDTO))]
        public async Task<ActionResult<DiscountDTO>> AddDiscount(DiscountCreationDTO newDiscount)
        {
            var addDiscount = await _discountService.AddDiscount(newDiscount);
            _repositoryService.SaveChanges();

            return CreatedAtRoute("GetDiscountByType", new { type = addDiscount.Type }, addDiscount);
        }


        [HttpOptions]
        public IActionResult GetDiscountsOption()
        {
            Response.Headers.Add("Allow", "GET,POST,OPTIONS");
            return Ok();

        }
    }
}
