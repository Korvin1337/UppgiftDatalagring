using Business.Dtos;
using Business.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services;

public class CustomerInputService(InputHandler inputHandler)
{
    private readonly InputHandler _inputHandler = inputHandler;

    public virtual CustomerRegistrationForm CollectCustomerData()
    {
        return new CustomerRegistrationForm
        {
            Name = _inputHandler.GetInput("Enter name: "),
            Email = _inputHandler.GetInput("Enter email: ")
        };
    }

    public virtual CustomerUpdateForm CollectCustomerUpdateData()
    {
        return new CustomerUpdateForm
        {
            Name = _inputHandler.GetInput("Enter name: "),
            Email = _inputHandler.GetInput("Enter email: ")
        };
    }
}
