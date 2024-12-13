using Domein.Models;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;
[ApiController]
[Route("Location/[controller]")]
public class LocationController
{
    private readonly LocationService _httpClient;

    public LocationController()
    {
        _httpClient = new LocationService();
    }

    [HttpGet("GetAllLocations")]
    public List<Location> GetAllLocations()
    {
        return _httpClient.GetAll();
    }

    [HttpGet("GetLocationById/{id}")]
    public Location GetLocationById(int id)
    {
        return _httpClient.GetById(id);
    }

    [HttpPost("AddLocation")]
    public string AddLocation(Location location)
    {
        return _httpClient.Add(location);   
    }

    [HttpPut("UpdateLocation")]
    public string UpdateLocation(Location location)
    {
        return _httpClient.Update(location);
    }

    [HttpDelete("DeleteLocation/{id}")]
    public string DeleteLocation(int id)
    {
        return _httpClient.Delete(id);
    }
}