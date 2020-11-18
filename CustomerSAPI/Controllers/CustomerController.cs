using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CustomerSAPI.Model;
using CustomerSAPI.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CustomerSAPI.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private ICustomerService service;

        public CustomerController(ICustomerService _service)
        {
            service = _service;
        }

        [HttpGet]
        public List<Customer> Get()
        {
            return service.GetCustomers();
        }
        [HttpGet]
        [Route("{id}")]
        public Customer Get(int id)
        {
            return service.GetCustomer(id);
        }

        [HttpPost]
        public void AddCustomer(Customer customer)
        {
            service.AddCustomer(customer);
        }

        [HttpDelete]
        [Route("{id}")]
        public void DeleteNote(int id)
        {
            service.DeleteCustomer(id);
        }

        [HttpPut]
        [Route("{id}")]
        public void Update(int id,Customer customer)
        {
            service.UpdateCustomer(id, customer);
            
        }


    }
}
