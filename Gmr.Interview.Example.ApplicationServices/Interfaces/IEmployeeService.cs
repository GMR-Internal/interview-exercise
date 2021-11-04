using Gmr.Interview.Example.DomainModels;
using Gmr.Interview.Example.ViewModels;
using System.Threading.Tasks;

namespace Gmr.Interview.Example.ApplicationServices.Interfaces
{
    public interface IEmployeeService
    {
        public Task<EmployeeViewModel> GetEmployeeByEmployeeId(int employeeId);

        public Task<EmployeeViewModel> CreateEmployee(EmployeeViewModel employeeViewModel);

        public Task<EmployeeViewModel> UpdateEmployee(int employeeId, EmployeeViewModel employeeViewModel);

        public Task<bool> DeleteEmployeeHard(int employeeId);

        public Task<bool> DeleteEmployeeSoft(int employeeId);
    }
}