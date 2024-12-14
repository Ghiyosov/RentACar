using Domein.Models;
using Infrastructure.ApiResponse;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[ApiController]
[Route("Rental/[controller]")]
public class RentalController : ControllerBase
{
    private readonly RentalService rentalService;

    public RentalController()
    {
        rentalService = new RentalService();
    }

    [HttpGet("GetAllRentals")]
    public Response<List<Rental>> GetRentals()
    {
        return rentalService.GetAll();
    }

    [HttpGet("GetRentalById/{id}")]
    public Response<Rental> GetRentalById(int id)
    {
        return rentalService.GetById(id);
    }

    [HttpPost("AddRental")]
    public Response<bool> AddRental(Rental rental)
    {
        return rentalService.Add(rental);
    }

    [HttpPut("UpdateRental")]
    public Response<bool> UpdateRental(Rental rental)
    {
        return rentalService.Update(rental);
    }

    [HttpDelete("DeleteRental/{id}")]
    public Response<bool> DeleteRental(int id)
    {
        return rentalService.Delete(id);
    }

    [HttpGet("GetCustomerRentals")]
    public Response<List<Rental>> GetCustomerRentals(int customerId)
    {
        return rentalService.SearchCustomerRentals(customerId);
    }
    
}