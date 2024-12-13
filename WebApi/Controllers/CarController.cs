using Domein.Models;
using Infrastructure.ApiResponse;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[ApiController]
[Route("Car/[controller]")]
public class CarController : ControllerBase 
{
    private readonly CarService _carService;

    public CarController()
    {
        _carService = new CarService();
    }

    [HttpGet("GetAllCars")]
    public Response<List<Car>> GetAllCars()
    {
        return _carService.GetAll();
    }

    [HttpGet("GetCarById/{id}")]
    public Response<Car> GetCarById(int id)
    {
        return _carService.GetById(id);
    }

    [HttpPost("AddCar")]
    public Response<bool> AddCar(Car car)
    {
        return _carService.Add(car);
    }

    [HttpPut("UpdateCar")]
    public Response<bool> UpdateCar(Car car)
    {
        return _carService.Update(car);
    }

    [HttpDelete("DeleteCar")]
    public Response<bool> DeleteCar(int id)
    {
        return _carService.Delete(id);
    }
}