using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShopsRCUS.Discount.API.Entities.DTOs;
using ShopsRCUS.Discount.API.Models;
using ShopsRCUS.Discount.API.Services.Interfaces;

namespace ShopsRCUS.Discount.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {

        private readonly IRepositoryService _repositoryService;
        private readonly IMapper _mapper;
        private readonly IHashingService _hashingService;

        public CustomersController(IRepositoryService repositoryService,
                                   IMapper mapper,
                                   IHashingService hashing)
        {
            _repositoryService = repositoryService ?? throw new ArgumentNullException(nameof(repositoryService));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _hashingService = hashing ?? throw new ArgumentNullException(nameof(hashing));
        }

        [HttpGet]
        public ActionResult<IEnumerable<CustomerDTO>> GetCustomers()
        {
            var customers = _repositoryService.GetAllCustomers();

            var clientResponse = _mapper.Map<IEnumerable<CustomerDTO>>(customers);


            return Ok(clientResponse);
        }
         

      


        [HttpGet("{idOrEmail}", Name = "GetCustomerById")]
        [Produces("application/json", "application/xml", Type = typeof(CustomerDTO))]
        public ActionResult<CustomerDTO> GetCustomer(string idOrEmail)
        {
            Customer customer = new Customer();
            Guid response = Guid.Empty;
            Guid.TryParse(idOrEmail.ToString(), out response);
            if (response != Guid.Empty)
            {

                customer = _repositoryService.GetCustomerById(response);
            }
            else
            {
                customer = _repositoryService.GetCustomerByName(idOrEmail.ToLower());
            }

            if (!(customer is object))
            {
                return NotFound();
            }

            var clientResponse = _mapper.Map<CustomerDTO>(customer);

            return Ok(clientResponse);

        }



        [HttpPost]
        public async Task<ActionResult> CreateCustomer(CustomerCreationDTO customer)
        {
            var customerEntity = _mapper.Map<Customer>(customer);
            var checkCustomer = _repositoryService.GetCustomerByName(customer.EmailAddress.ToLower());
            if (checkCustomer is object)
            {

                customerEntity.Id = Guid.Empty;
                return Conflict(_mapper.Map<CustomerDTO>(customerEntity));
            }

            customerEntity.PasswordHashed = _hashingService.HashString(customer.Password);
            var resp =await _repositoryService.AddCustomer(customerEntity);

            if (!resp)
            { 
                return BadRequest();
            }

            _repositoryService.SaveChanges();

           var clientResponse = _mapper.Map<CustomerDTO>(customerEntity);

            return CreatedAtRoute("GetCustomerById", new { idOREmail = clientResponse.Id.ToString() }, clientResponse);
        
        }

        [HttpOptions]
        public IActionResult GetCustomerOption()
        {
            Response.Headers.Add("Allow", "GET,POST,OPTIONS");
            return Ok();
        
        }

    }
}
