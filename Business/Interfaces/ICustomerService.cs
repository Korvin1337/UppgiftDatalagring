using Business.Dtos;
using Business.Models;
using Data.Entities;
using System.Linq.Expressions;

namespace Business.Interfaces
{
    public interface ICustomerService
    {
        Task<bool> AlreadyExistsAsync(Expression<Func<CustomerEntity, bool>> expression);
        Task<Customer> CreateCustomerAsync(CustomerRegistrationForm form);
        Task<bool> DeleteCustomerAsync(int id);
        Task<IEnumerable<Customer>> GetAllCustomersAsync();
        Task<CustomerEntity> GetCustomerAsync(Expression<Func<CustomerEntity, bool>> expression);
        Task<Customer> UpdateCustomerAsync(CustomerUpdateForm form);
    }
}