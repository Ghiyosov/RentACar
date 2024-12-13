using Dapper;
using Domein.Models;
using Infrastructure.DataContext;

namespace Infrastructure.Services;

public class CarLokationService
{
    readonly DapperContext _context;

    public CarLokationService()
    {
        _context = new DapperContext();
    }

    public string AddCarLocation(CarLocation carLocation)
    {
        var sql = "inser into CarLocations(CarId,LocationId),values(@CarId,@LocationId)returning CarId";
        var res = _context.GetConnection().QuerySingle<string>(sql, carLocation);
        return $"Car {res} was added to the Location {carLocation.CarId}";
    }
    
    public string DeleteCarLocation(CarLocation carLocation)
    {
        var sql = "delete from CarLocations where CarId = @CarId and LocationId = @LocationId returning CarId";
        var res = _context.GetConnection().QuerySingle<string>(sql, carLocation);
        return $"Car {res} was deleted to the Location {carLocation.CarId}";
    }

    public List<Car> GetAllCarInLocations(int? locationId)
    {
        var sql = "select * from CarLocations where LocationId = @LocationId";
        var res = _context.GetConnection().Query<Car>(sql, new { LocationId = locationId }).ToList();
        return res;
    }
}