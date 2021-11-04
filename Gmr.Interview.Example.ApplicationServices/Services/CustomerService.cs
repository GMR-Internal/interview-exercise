using AutoMapper;
using AutoMapper.Configuration;
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
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;
        private readonly IRepository<Customer> _customerRepository;

        public CustomerService(IMapper mapper, IConfiguration configuration, IRepository<Customer> customerRepository)
        {
            _mapper = mapper;
            _configuration = configuration;
            _customerRepository = customerRepository;
        }

        public async Task<CustomerViewModel> GetCustomerByCustomerId(int customerId)
        {
            var customer = await _customerRepository.FirstOrDefaultAsync(x => x.CustomerId == customerId);

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
            var customer = await _customerRepository.FirstOrDefaultAsync(x => x.CustomerId == customerId);

            await _customerRepository.DeleteAsync(customer);

            return await _customerRepository.SaveChangesAsync() > 0;
        }

        public async Task<bool> DeleteCustomerSoft(int customerId)
        {
            var customer = await _customerRepository.FirstOrDefaultAsync(x => x.CustomerId == customerId);

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