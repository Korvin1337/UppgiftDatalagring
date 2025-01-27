using Business.Dtos;
using Business.Models;
using Data.Entities;
using System.Linq.Expressions;

namespace Business.Interfaces;

public interface ICustomerService
{
    Task<IResult> CreateCustomerAsync(CustomerRegistrationForm form);
    Task<IResult> GetAllCustomersAsync();
    /*Task<IResult> AlreadyExistsAsync();*/
    Task<IResult> GetCustomerAsync(int id);
    Task<IResult> UpdateCustomerAsync(int id, CustomerUpdateForm form);
    Task<IResult> DeleteCustomerAsync(int id);
}