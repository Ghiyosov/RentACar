using Domein.Models;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[ApiController]
[Route("Customer/[controller]")]
public class CustomerController
{
    private readonly CustomerService _customerService;

    public CustomerController()
    {
        _customerService = new CustomerService();
    }

    [HttpGet("GetAll")]
    public List<Customer> GetAll()
    {
        return _customerService.GetAll();
    }

    [HttpGet("GetById/{id}")]
    public Customer GetById(int id)
    {
        return _customerService.GetById(id);
    }

    [HttpPost("Add")]
    public string Add(Customer customer)
    {
        return _customerService.Add(customer);
    }

    [HttpPut("Update")]
    public string Update(Customer customer)
    {
        return _customerService.Update(customer);
    }

    [HttpDelete("Delete/{id}")]
    public string Delete(int id)
    {
        return _customerService.Delete(id);
    }
}