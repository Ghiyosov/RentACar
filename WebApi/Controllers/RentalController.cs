using Domein.Models;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[ApiController]
[Route("Rental/[controller]")]
public class RentalController
{
    private readonly RentalService rentalService;

    public RentalController()
    {
        rentalService = new RentalService();
    }

    [HttpGet("GetAllRentals")]
    public List<Rental> GetRentals()
    {
        return rentalService.GetAll();
    }

    [HttpGet("GetRentalById/{id}")]
    public Rental GetRentalById(int id)
    {
        return rentalService.GetById(id);
    }

    [HttpPost("AddRental")]
    public string AddRental(Rental rental)
    {
        return rentalService.Add(rental);
    }

    [HttpPut("UpdateRental")]
    public string UpdateRental(Rental rental)
    {
        return rentalService.Update(rental);
    }

    [HttpDelete("DeleteRental/{id}")]
    public string DeleteRental(int id)
    {
        return rentalService.Delete(id);
    }

    [HttpGet("GetCustomerRentals")]
    public List<Rental> GetCustomerRentals(int customerId)
    {
        return rentalService.SearchCustomerRentals(customerId);
    }
    
}