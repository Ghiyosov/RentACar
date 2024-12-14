using Domein.Models;
using Infrastructure.ApiResponse;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[ApiController]
[Route("Customer/[controller]")]
public class CustomerController : ControllerBase
{
    private readonly CustomerService _customerService;

    public CustomerController()
    {
        _customerService = new CustomerService();
    }

    [HttpGet("GetAll")]
    public Response<List<Customer>> GetAll()
    {
        return _customerService.GetAll();
    }

    [HttpGet("GetById/{id}")]
    public Response<Customer> GetById(int id)
    {
        return _customerService.GetById(id);
    }

    [HttpPost("Add")]
    public Response<bool> Add(Customer customer)
    {
        return _customerService.Add(customer);
    }

    [HttpPut("Update")]
    public Response<bool> Update(Customer customer)
    {
        return _customerService.Update(customer);
    }

    [HttpDelete("Delete/{id}")]
    public Response<bool> Delete(int id)
    {
        return _customerService.Delete(id);
    }
}