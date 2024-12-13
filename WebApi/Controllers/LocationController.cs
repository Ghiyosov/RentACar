using Domein.Models;
using Infrastructure.ApiResponse;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;
[ApiController]
[Route("Location/[controller]")]
public class LocationController : ControllerBase
{
    private readonly LocationService _httpClient;

    public LocationController()
    {
        _httpClient = new LocationService();
    }

    [HttpGet("GetAllLocations")]
    public Response<List<Location>> GetAllLocations()
    {
        return _httpClient.GetAll();
    }

    [HttpGet("GetLocationById/{id}")]
    public Response<Location> GetLocationById(int id)
    {
        return _httpClient.GetById(id);
    }

    [HttpPost("AddLocation")]
    public Response<bool> AddLocation(Location location)
    {
        return _httpClient.Add(location);   
    }

    [HttpPut("UpdateLocation")]
    public Response<bool> UpdateLocation(Location location)
    {
        return _httpClient.Update(location);
    }

    [HttpDelete("DeleteLocation/{id}")]
    public Response<bool> DeleteLocation(int id)
    {
        return _httpClient.Delete(id);
    }
}