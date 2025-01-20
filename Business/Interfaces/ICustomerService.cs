using Business.Dtos;
using Business.Models;
using Data.Entities;

namespace Business.Interfaces
{
    public interface ICustomerService
    {
        CustomerEntity CreateCustomer(CustomerRegistrationForm form);
        bool DeleteCustomerById(int id);
        CustomerEntity GetCustomerById(int id);
        IEnumerable<Customer> GetAllCustomers();
        CustomerEntity UpdateCustomer(CustomerEntity customerEntity);
    }
}