using ecom_web_app.Customers.Models;
using ecom_web_app.Customers.Services;
using Microsoft.AspNetCore.Mvc;

namespace ecom_web_app.customer_service.Controllers;



[ApiController]
[Route("/customer")]
public class CustomerController : ControllerBase
{
    private readonly ICustomerRepository customerRepository;
    
    public CustomerController(ICustomerRepository customerRepository)
    {
        this.customerRepository = customerRepository;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Customer>>> getAllCustomers()
    {
        var customers = await customerRepository.getAllCustomers();
        return Ok(customers);
    }

    [HttpGet("/customer/{id}")]
    public async Task<ActionResult<Customer>> getCustomerById(string id)
    {
        var customer = await customerRepository.getCustomerById(id);
        if (customer == null)
        {
            return NotFound();
        }
        return Ok(customer);
        
    }

    [HttpPost]
    public async Task<ActionResult<Customer>> createCustomer(Customer customer)
    {
        var created = await customerRepository.CreateCustomer(customer);
        return CreatedAtAction(
            nameof(getCustomerById),
            new { id = created.Id },
            created
            );
    }

    [HttpPut("/customer/update/{id}")]
    public async Task<ActionResult<Customer>> UpdateCustomer(string id , Customer customer)
    {
        var updated = await customerRepository.UpdateCustomer(id , customer);

        if (updated == null)
        {
            return NotFound();
        }

        return Ok(updated);
    } 
    
    
    [HttpDelete("/customer/delete/{id}")]
    public async Task<IActionResult> DeleteCustomer(string id)
    {
        await customerRepository.DeleteCustomer(id);
        return NoContent();
    }
    
}