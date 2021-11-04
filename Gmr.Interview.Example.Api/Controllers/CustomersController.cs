using Gmr.Interview.Example.ApplicationServices.Interfaces;
using Gmr.Interview.Example.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace Gmr.Interview.Example.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CustomersController : ControllerBase
    {
        private readonly ILogger<CustomersController> _logger;

        private readonly ICustomerService _customerService;

        public CustomersController(ILogger<CustomersController> logger)
        {
            _logger = logger;
        }

        // GET api/customers/5
        [HttpGet("{customerId}")]
        public async Task<CustomerViewModel> GetById(int customerId)
        {
            return await _customerService.GetCustomerByCustomerId(customerId);
        }

        // POST api/customers
        [HttpPost]
        public async Task<CustomerViewModel> Post([FromBody] CustomerViewModel customerViewModel)
        {
            return await _customerService.CreateCustomer(customerViewModel);
        }

        // PUT api/customers/5
        [HttpPut("{customerId}")]
        public async Task<CustomerViewModel> Put(int customerId, [FromBody] CustomerViewModel customerViewModel)
        {
            return await _customerService.UpdateCustomer(customerId, customerViewModel);
        }

        // DELETE api/customers/5/HardDelete
        [HttpDelete("{customerId}/HardDelete")]
        public async Task<bool> HardDelete(int customerId)
        {
            return await _customerService.DeleteCustomerHard(customerId);
        }

        // DELETE api/customers/5/SoftDelete
        [HttpDelete("{customerId}/SoftDelete")]
        public async Task<bool> SoftDelete(int customerId)
        {
            return await _customerService.DeleteCustomerSoft(customerId);
        }
    }
}