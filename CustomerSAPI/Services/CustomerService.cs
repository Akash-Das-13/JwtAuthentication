using CustomerSAPI.Model;
using CustomerSAPI.Repositories;
using CustomerSAPI.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerSAPI.Services
{
    public class CustomerService : ICustomerService
    {
        private ICustomerRepositories repo;

        public CustomerService(ICustomerRepositories _repo)
        {
            repo = _repo;
        }
        public int AddCustomer(Customer customer)
        {
            return repo.AddCustomer(customer);
        }

        public int DeleteCustomer(int id)
        {
            return repo.DeleteCustomer(id);
        }

        public Customer GetCustomer(int id)
        {
            return repo.GetCustomer(id);
        }

        public List<Customer> GetCustomers()
        {
            return repo.GetCustomers();
        }

        public int UpdateCustomer(int id, Customer customer)
        {
            return repo.UpdateCustomer(id,customer);
        }
    }
}
