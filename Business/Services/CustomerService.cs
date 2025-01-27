using Business.Dtos;
using Business.Factories;
using Business.Interfaces;
using Business.Models;
using Data.Contexts;
using Data.Entities;
using Data.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services;

public class CustomerService(ICustomerRepository customerRepository) : ICustomerService
{
    private readonly ICustomerRepository _customerRepository = customerRepository;

    /*public async Task<IResult> AlreadyExistsAsync()
    {
        throw new NotImplementedException();
    }*/

    public async Task<IResult> CreateCustomerAsync(CustomerRegistrationForm form)
    {
        if (form == null)
            return Result.BadRequest("Invalid registration form");

        try
        {
            if (await _customerRepository.ExistsAsync(x => x.Name == form.Name))
                return Result.AlreadyExcists("Customer with same name already excists");

            var customerEntity = CustomerFactory.Create(form);

            var result = await _customerRepository.CreateAsync(customerEntity);
            return result ? Result.Ok() : Result.Error("Unable to create customer.");
        } catch (Exception ex)
        {
            Debug.Write(ex.Message);
            return Result.Error(ex.Message);
        }
    }

    public async Task<IResult> GetAllCustomersAsync()
    {
        try
        {
            var customerEntities = await _customerRepository.GetAllSync();
            var customers = customerEntities?.Select(CustomerFactory.Create);

            return Result<IEnumerable<Customer>>.Ok(customers);
        }
        catch (Exception ex)
        {
            Debug.Write(ex.Message);
            return Result.Error(ex.Message);
        }
    }

    public async Task<IResult> GetCustomerAsync(int id)
    {
        try
        {
            var customerEntity = await _customerRepository.GetAsync(x => x.CustomerId == id);
            if (customerEntity == null)
                return Result.NotFound("Customer was not found.");

            var customer = CustomerFactory.Create(customerEntity);
            return Result<Customer>.Ok(customer);
        }
        catch (Exception ex)
        {
            Debug.Write(ex.Message);
            return Result.Error(ex.Message);
        }
    }

    public async Task<IResult> UpdateCustomerAsync(int id, CustomerUpdateForm form)
    {
        try
        {
            var customerEntity = await _customerRepository.GetAsync(x => x.CustomerId == id);
            if (customerEntity == null)
                return Result.NotFound("Customer was not found.");

            customerEntity = CustomerFactory.Create(customerEntity, form);
            var result = await _customerRepository.UpdateAsync(customerEntity);

            return result ? Result.Ok() : Result.Error("Unable to update customer.");
        }
        catch (Exception ex)
        {
            Debug.Write(ex.Message);
            return Result.Error(ex.Message);
        }
    }

    public async Task<IResult> DeleteCustomerAsync(int id)
    {
        try
        {
            var customerEntity = await _customerRepository.GetAsync(x => x.CustomerId == id);
            if (customerEntity == null)
                return Result.NotFound("Customer was not found.");

            var result = await _customerRepository.DeleteAsync(customerEntity);
            return result ? Result.Ok() : Result.Error("Unable to delete customer.");
        }
        catch (Exception ex)
        {
            Debug.Write(ex.Message);
            return Result.Error(ex.Message);
        }
    }
}
