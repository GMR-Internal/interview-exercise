using Gmr.Interview.Example.ApplicationServices.Interfaces;
using Gmr.Interview.Example.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace Gmr.Interview.Example.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeesController : ControllerBase
    {
        private readonly ILogger<EmployeesController> _logger;

        private readonly IEmployeeService _employeeService;

        public EmployeesController(ILogger<EmployeesController> logger,
            IEmployeeService employeeService)
        {
            _logger = logger;
            _employeeService = employeeService;
        }

        // GET api/employees/5
        [HttpGet("{employeeId}")]
        public async Task<EmployeeViewModel> GetById(int employeeId)
        {
            return await _employeeService.GetEmployeeByEmployeeId(employeeId);
        }

        // POST api/employees
        [HttpPost]
        public async Task<EmployeeViewModel> Post([FromBody] EmployeeViewModel employeeViewModel)
        {
            return await _employeeService.CreateEmployee(employeeViewModel);
        }

        // PUT api/employees/5
        [HttpPut("{employeeId}")]
        public async Task<EmployeeViewModel> Put(int employeeId, [FromBody] EmployeeViewModel employeeViewModel)
        {
            return await _employeeService.UpdateEmployee(employeeId, employeeViewModel);
        }

        // DELETE api/employees/5/HardDelete
        [HttpDelete("{employeeId}/HardDelete")]
        public async Task<bool> HardDelete(int employeeId)
        {
            return await _employeeService.DeleteEmployeeHard(employeeId);
        }

        // DELETE api/employees/5/SoftDelete
        [HttpDelete("{employeeId}/SoftDelete")]
        public async Task<bool> SoftDelete(int employeeId)
        {
            return await _employeeService.DeleteEmployeeSoft(employeeId);
        }
    }
}
