using Dapper;
using Domein.Models;
using Infrastructure.DataContext;

namespace Infrastructure.Services;

public class CarService: ICrudService<Car>
{
    
    readonly DapperContext _context;

    public CarService()
    {
        _context = new DapperContext();
    }
    
    public List<Car> GetAll()
    {
        var sql = "select * from Cars";
        var res = _context.GetConnection().Query<Car>(sql).ToList();
        return res;
    }

    public Car GetById(int id)
    {
        var sql = "select * from Cars where CarId = @Id";
        var res = _context.GetConnection().QueryFirstOrDefault<Car>(sql, new { Id = id });
        return res;
    }

    public string Add(Car entity)
    {
        var sql = "insert into Cars (Model, Manufacturer,Year,PricePerDay) values (@Model, @Manufacturer, @Year, @PricePerDay) returning Model;";
        var res = _context.GetConnection().QuerySingle<string>(sql, entity);
        return $"Car {res} is added";
    }

    public string Update(Car entity)
    {
        var sql = "update Cars set Model=@Model, Manufacturer=@Manufacturer, Year=@Year, PricePerDay=@PricePerDay where CarId = @CarId returning CarId";
        var res = _context.GetConnection().QuerySingle<string>(sql, entity);
        return $"Car {res} is updated";
    }

    public string Delete(int entity)
    {
        var sqlRentals = "select * from Rentals where CarId = @Id";
        var resRental = _context.GetConnection().QueryFirstOrDefault<Rental>(sqlRentals, new { Id = entity });
        if (resRental.CarId != entity)
        {
            var sql = "delete from Cars where CarId = @Id returning CarId";
            var res = _context.GetConnection().QuerySingle<string>(sql, new { Id = entity });
            return $"Car {res} is deleted";
        }
        else return $"Car {resRental.CarId} is already rented";
    }
}