using Business.Dtos;
using Data.Entities;

namespace Business.Interfaces
{
    public interface ICustomerService
    {
        CustomerEntity CreateCustomer(CustomerRegistrationForm form);
        bool DeleteCustomerById(int id);
        CustomerEntity GetCustomer(int id);
        IEnumerable<CustomerEntity> GetAllCustomers();
        CustomerEntity UpdateCustomer(CustomerEntity customerEntity);
    }
}