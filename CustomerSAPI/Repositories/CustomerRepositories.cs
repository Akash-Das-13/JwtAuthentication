using CustomerSAPI.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerSAPI.Repositories
{
    public class CustomerRepositories : ICustomerRepositories
    {
        private DataContext context;

        public CustomerRepositories(DataContext _context)
        {
            context = _context;
        }
        public int AddCustomer(Customer customer)
        {
            context.Customers.Add(customer);
            return context.SaveChanges();
        }

        

        public Customer GetCustomer(int id)
        {
            return context.Customers.Where(c => c.CustomerId == id).FirstOrDefault();
        }

        public List<Customer> GetCustomers()
        {
            return context.Customers.ToList();
        }

        public int DeleteCustomer(int id)
        {
            Customer cus = context.Customers.Where(c => c.CustomerId == id).FirstOrDefault();
            context.Customers.Remove(cus);
            return context.SaveChanges();
        }

        public int UpdateCustomer(int id, Customer customer)
        {
            Customer cus = context.Customers.Where(c => c.CustomerId == id).FirstOrDefault();
            cus.Name = customer.Name;
            cus.Email = customer.Email;
            cus.Address = customer.Address;
            context.Entry<Customer>(cus).State = EntityState.Modified;
            return context.SaveChanges();

        }
    }
}
