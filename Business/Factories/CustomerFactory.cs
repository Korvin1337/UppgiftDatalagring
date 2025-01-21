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
        Email = form.Email
    };

    public static Customer Create(CustomerEntity entity) => new()
    {
        CustomerId = entity.CustomerId,
        Name = entity.Name,
        Email = entity.Email
    };

    public static CustomerUpdateForm Create(Customer customer) => new()
    {
        CustomerId = customer.CustomerId,
        Name = customer.Name,
        Email = customer.Email
    };

    public static CustomerEntity Create(CustomerUpdateForm form) => new()
    {
        CustomerId = form.CustomerId,
        Name = form.Name,
        Email = form.Email
    };
}
