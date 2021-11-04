using Gmr.Interview.Example.DomainModels;
using Gmr.Interview.Example.ViewModels;
using System.Threading.Tasks;

namespace Gmr.Interview.Example.ApplicationServices.Interfaces
{
    public interface ICustomerService
    {
        public Task<CustomerViewModel> GetCustomerByCustomerId(int customerId);

        public Task<CustomerViewModel> CreateCustomer(CustomerViewModel customerViewModel);

        public Task<CustomerViewModel> UpdateCustomer(int customerId, CustomerViewModel customerViewModel);

        public Task<bool> DeleteCustomerHard(int customerId);

        public Task<bool> DeleteCustomerSoft(int customerId);
    }
}