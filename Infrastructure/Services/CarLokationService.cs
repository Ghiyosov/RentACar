using System.Net;
using Dapper;
using Domein.Models;
using Infrastructure.ApiResponse;
using Infrastructure.DataContext;

namespace Infrastructure.Services;

public class CarLokationService
{
    readonly DapperContext _context;

    public CarLokationService()
    {
        _context = new DapperContext();
    }

    public Response<bool> AddCarLocation(CarLocation carLocation)
    {
        var sql = "inser into CarLocations(CarId,LocationId),values(@CarId,@LocationId)";
        var res = _context.GetConnection().Execute(sql, carLocation);
        return res==0
            ? new Response<bool>(HttpStatusCode.InternalServerError,"Iternal Server Error")
            : new Response<bool>(HttpStatusCode.Created, "created carlocation successfully");
    }
    
    public Response<bool> DeleteCarLocation(CarLocation carLocation)
    {
        var sql = "delete from CarLocations where CarId = @CarId and LocationId = @LocationId;";
        var res = _context.GetConnection().Execute(sql, carLocation);
        return res==0
            ? new Response<bool>(HttpStatusCode.InternalServerError,"Iternal Server Error")
            : new Response<bool>(HttpStatusCode.OK, "Car location deleted successfully");
    }

    public Response<List<Car>> GetAllCarInLocations(int? locationId)
    {
        var sql = "select * from CarLocations where LocationId = @LocationId";
        var res = _context.GetConnection().Query<Car>(sql, new { LocationId = locationId }).ToList();
        return new Response<List<Car>>(res);
    }
}