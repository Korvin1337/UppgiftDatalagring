using Data.Entities;

namespace Business.Interfaces
{
    public interface ICustomerService
    {
        CustomerEntity CreateCustomer(CustomerEntity customerEntity);
        bool DeleteCustomerById(int id);
        CustomerEntity GetCustomer(int id);
        IEnumerable<CustomerEntity> GetCustomers();
        CustomerEntity UpdateCustomer(CustomerEntity customerEntity);
    }
}