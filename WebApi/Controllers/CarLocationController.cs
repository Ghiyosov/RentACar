using Domein.Models;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[ApiController]
[Route("CarLocation/[controller]")]
public class CarLocationController
{
    private readonly CarLokationService _carLocationServices;

    public CarLocationController()
    {
        _carLocationServices = new CarLokationService();
    }

    [HttpPost("AddCarLocation")]
    public string AddCarLocation(CarLocation carLocation)
    {
        return _carLocationServices.AddCarLocation(carLocation);
    }

    [HttpDelete("DeleteCarLocation")]
    public string DeleteCarLocation(CarLocation carLocation)
    {
        return _carLocationServices.DeleteCarLocation(carLocation);
    }

    [HttpGet("GetAllCarInLocations")]
    public List<Car> GetAllCarInLocations(int? locationId)
    {
        return _carLocationServices.GetAllCarInLocations(locationId);
    }
}

