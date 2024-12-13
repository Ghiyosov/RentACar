using Domein.Models;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[ApiController]
[Route("Car/[controller]")]
public class CarController
{
    private readonly CarService _carService;

    public CarController()
    {
        _carService = new CarService();
    }

    [HttpGet("GetAllCars")]
    public List<Car> GetAllCars()
    {
        return _carService.GetAll();
    }

    [HttpGet("GetCarById/{id}")]
    public Car GetCarById(int id)
    {
        return _carService.GetById(id);
    }

    [HttpPost("AddCar")]
    public string AddCar(Car car)
    {
        return _carService.Add(car);
    }

    [HttpPut("UpdateCar")]
    public string UpdateCar(Car car)
    {
        return _carService.Update(car);
    }

    [HttpDelete("DeleteCar")]
    public string DeleteCar(int id)
    {
        return _carService.Delete(id);
    }
}