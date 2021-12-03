using AutoMapper;
using Gmr.Interview.Example.ApplicationServices.Interfaces;
using Gmr.Interview.Example.DomainModels;
using Gmr.Interview.Example.DomainServices.Repositories;
using Gmr.Interview.Example.ViewModels;
using Serilog;
using System.Threading.Tasks;

namespace Gmr.Interview.Example.ApplicationServices.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly ILogger _logger = Log.ForContext<EmployeeService>();
        private readonly IRepository<Employee> _employeeRepository;
        private readonly IMapper _mapper;

        public EmployeeService(IRepository<Employee> employeeRepository,
            IMapper mapper)
        {
            _employeeRepository = employeeRepository;
            _mapper = mapper;
        }

        public async Task<EmployeeViewModel> GetEmployeeByEmployeeId(int employeeId)
        {
            var employee = await _employeeRepository.FirstOrDefaultAsync(x => x.Id == employeeId);

            return _mapper.Map<EmployeeViewModel>(employee);
        }

        public async Task<EmployeeViewModel> CreateEmployee(EmployeeViewModel employeeViewModel)
        {
            var employee = _mapper.Map<Employee>(employeeViewModel);

            await _employeeRepository.AddAsync(employee);
            await _employeeRepository.SaveChangesAsync();

            return employeeViewModel;
        }

        public async Task<EmployeeViewModel> UpdateEmployee(int employeeId, EmployeeViewModel employeeViewModel)
        {
            var updatedEmployee = _employeeRepository.UpdateAsync(_mapper.Map<Employee>(employeeViewModel));

            await _employeeRepository.SaveChangesAsync();

            return employeeViewModel;
        }

        public async Task<bool> DeleteEmployeeHard(int employeeId)
        {
            var employee = await _employeeRepository.FirstOrDefaultAsync(x => x.Id == employeeId);

            await _employeeRepository.DeleteAsync(employee);
            
            return await _employeeRepository.SaveChangesAsync() > 0;
        }

        public async Task<bool> DeleteEmployeeSoft(int employeeId)
        {
            var employee = await _employeeRepository.FirstOrDefaultAsync(x => x.Id == employeeId);

            if (employee != null)
            {
                employee.IsDeleted = true;

                await _employeeRepository.UpdateAsync(employee);

                return await _employeeRepository.SaveChangesAsync() > 0;
            }
            
            return true;
        }
    }
}
