using Business.Dtos;
using Business.Models;
using Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Factories;

public static class CustomerFactory
{
    public static CustomerRegistrationForm Create() => new();

    public static CustomerEntity Create(CustomerRegistrationForm form) => new()
    {
        Name = form.Name,
        Email = form.Email.ToLower()
    };

    public static Customer Create(CustomerEntity entity) => new()
    {
        CustomerId = entity.CustomerId,
        Name = entity.Name,
        Email = entity.Email
    };

    public static CustomerUpdateForm Create(Customer customer) => new()
    {
        Name = customer.Name,
        Email = customer.Email
    };

    public static CustomerEntity Create(CustomerEntity customerEntity, CustomerUpdateForm form) => new()
    {
        CustomerId = customerEntity.CustomerId,
        Name = form.Name,
        Email = form.Email
    };
}
