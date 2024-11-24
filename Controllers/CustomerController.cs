using Challenge.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Challenge.Controllers
{
    [ApiController]
    [Authorize]
    [Route("api/[controller]")]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomerController(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        [HttpGet]
        [Route("Get")]
        public async Task<IActionResult> Get([FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 100)
        {
            var customerDomainModel = await _customerRepository.GetAllAsync(pageNumber, pageSize);

            return Ok(customerDomainModel);
        }

        [HttpPost]
        [Route("Create")]
        public async Task<IActionResult> Create([FromBody] Customer addCustomer)
        {
            await _customerRepository.CreateAsync(addCustomer);

            return Ok(addCustomer);
        }

        [HttpPut]
        [Route("Update")]
        public async Task<IActionResult> Update(Customer customer)
        {
            var customerUpdate = await _customerRepository.UpdateAsync(customer.CustomerNumber, customer);

            if (customerUpdate == null)
            {
                return NotFound();
            }

            return Ok(customerUpdate);
        }
    }
}
