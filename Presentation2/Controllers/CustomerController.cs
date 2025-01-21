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
    public async Task<IActionResult> Create(CustomerRegistrationForm form)
    {
        try
        {
            if (ModelState.IsValid)
            {
                if (await _customerService.AlreadyExistsAsync(x => x.Name == form.Name))
                {
                    return Conflict("Customer with same name already excists");
                }

                var customer = await _customerService.CreateCustomerAsync(form);
                if (customer != null)
                {
                    return Ok(customer);
                }
                return Ok(customer);
            }

            return BadRequest();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }


    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        try
        {
            var customer = await _customerService.GetAllCustomersAsync();
            return Ok(customer);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}
