using AutoMapper;
using Gmr.Interview.Example.ApplicationServices.Interfaces;
using Gmr.Interview.Example.DomainModels;
using Gmr.Interview.Example.DomainServices.Repositories;
using Gmr.Interview.Example.ViewModels;
using Serilog;
using System.Threading.Tasks;

namespace Gmr.Interview.Example.ApplicationServices.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ILogger _logger = Log.ForContext<CustomerService>();
        private readonly IRepository<Customer> _customerRepository;
        private readonly IMapper _mapper;

        public CustomerService(IRepository<Customer> customerRepository,
            IMapper mapper)
        {
            _customerRepository = customerRepository;
            _mapper = mapper;
        }

        public async Task<CustomerViewModel> GetCustomerByCustomerId(int customerId)
        {
            var customer = await _customerRepository.FirstOrDefaultAsync(x => x.Id == customerId);

            return _mapper.Map<CustomerViewModel>(customer);
        }

        public async Task<CustomerViewModel> CreateCustomer(CustomerViewModel customerViewModel)
        {
            var customer = _mapper.Map<Customer>(customerViewModel);

            await _customerRepository.AddAsync(customer);
            await _customerRepository.SaveChangesAsync();

            return customerViewModel;
        }

        public async Task<CustomerViewModel> UpdateCustomer(int customerId, CustomerViewModel customerViewModel)
        {
            var updatedCustomer = _customerRepository.UpdateAsync(_mapper.Map<Customer>(customerViewModel));

            await _customerRepository.SaveChangesAsync();

            return customerViewModel;
        }

        public async Task<bool> DeleteCustomerHard(int customerId)
        {
            var customer = await _customerRepository.FirstOrDefaultAsync(x => x.Id == customerId);

            await _customerRepository.DeleteAsync(customer);

            return await _customerRepository.SaveChangesAsync() > 0;
        }

        public async Task<bool> DeleteCustomerSoft(int customerId)
        {
            var customer = await _customerRepository.FirstOrDefaultAsync(x => x.Id == customerId);

            if (customer != null)
            {
                customer.IsDeleted = true;

                await _customerRepository.UpdateAsync(customer);

                return await _customerRepository.SaveChangesAsync() > 0;
            }

            return true;
        }
    }
}
