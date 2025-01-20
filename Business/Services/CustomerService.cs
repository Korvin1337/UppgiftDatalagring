using Business.Dtos;
using Business.Interfaces;
using Data.Contexts;
using Data.Entities;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services;

public class CustomerService(DataContext context) : ICustomerService
{
    private readonly DataContext _context = context;

    public CustomerEntity CreateCustomer(CustomerRegistrationForm form)
    {
        try {
            var customerEntity = new CustomerEntity
            {
                Name = form.Name,
                Email = form.Email
            };
            _context.Customers.Add(customerEntity);
            _context.SaveChanges();

            return customerEntity;

        } catch (Exception ex) {
            Debug.Write(ex);
            return null!;
        }
    }

    public IEnumerable<CustomerEntity> GetAllCustomers()
    {
        try {
            return _context.Customers;
        } catch (Exception ex) {
            Debug.Write(ex);
            return null!;
        }
    }

    public CustomerEntity GetCustomer(int id)
    {
        try {
            var customerEntity = _context.Customers.FirstOrDefault(x => x.CustomerId == id);

            return customerEntity ?? null!;
        } catch (Exception ex) {
            Debug.Write(ex);
            return null!;
        }
    }

    public CustomerEntity UpdateCustomer(CustomerEntity customerEntity)
    {
        try {
            _context.Customers.Update(customerEntity);
            _context.SaveChanges();

            return customerEntity;
        }
        catch (Exception ex) {
            Debug.Write(ex);
            return null!;
        }
    }

    public bool DeleteCustomerById(int id) /* Use CustomerEntity customerEntity if needed */
    {
        try {
            var customerEntity = _context.Customers.FirstOrDefault(x => x.CustomerId == id);

            if (customerEntity != null)
            {
                _context.Remove(customerEntity);
                _context.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        } catch (Exception ex)
        {
            Debug.Write(ex);
            return false!;
        }

    }
}
