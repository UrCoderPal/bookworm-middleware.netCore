using BookWorm_C_.Entities;
using BookWorm_C_.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

[Route("api/customers")]
[ApiController]
public class CustomerController : ControllerBase
{
    private readonly SQLCustomerRepository _customerService;

    public CustomerController(SQLCustomerRepository customerService)
    {
        _customerService = customerService;
    }

    [HttpGet]
    public async Task<ActionResult<List<Customer>>> GetAllCustomersAsync()
    {
        var customers = await _customerService.GetAllCustomers();
        return Ok(customers);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Customer>> GetCustomerByIdAsync(long id)
    {
        var customer = await _customerService.GetById(id);

        if (customer == null)
        {
            return NotFound();
        }

        return Ok(customer);
    }

    // Add more controller methods for handling other HTTP requests as needed
}
