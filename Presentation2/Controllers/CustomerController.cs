using Microsoft.AspNetCore.Mvc;
using Business.Interfaces;
using Business.Dtos;

namespace Presentation2.Controllers;

[Route("api/customers")]
[ApiController]
public class CustomersController(ICustomerService customerService) : ControllerBase
{
    private readonly ICustomerService _customerService = customerService;

    [HttpPost]
    public IActionResult Create(CustomerRegistrationForm form)
    {
        try
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var result = _customerService.CreateCustomer(form);
            return Ok(result);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }


    [HttpGet]
    public IActionResult GetAll()
    {
        try
        {
            var customer = _customerService.GetAllCustomers();
            return Ok(customer);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}
