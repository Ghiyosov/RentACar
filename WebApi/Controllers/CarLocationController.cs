using Domein.Models;
using Infrastructure.ApiResponse;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[ApiController]
[Route("CarLocation/[controller]")]
public class CarLocationController : ControllerBase
{
    private readonly CarLokationService _carLocationServices;

    public CarLocationController()
    {
        _carLocationServices = new CarLokationService();
    }

    [HttpPost("AddCarLocation")]
    public Response<bool> AddCarLocation(CarLocation carLocation)
    {
        return _carLocationServices.AddCarLocation(carLocation);
    }

    [HttpDelete("DeleteCarLocation")]
    public Response<bool> DeleteCarLocation(CarLocation carLocation)
    {
        return _carLocationServices.DeleteCarLocation(carLocation);
    }

    [HttpGet("GetAllCarInLocations")]
    public Response<List<Car>> GetAllCarInLocations(int? locationId)
    {
        return _carLocationServices.GetAllCarInLocations(locationId);
    }
}

