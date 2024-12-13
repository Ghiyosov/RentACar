using Dapper;
using Domein.Models;
using Infrastructure.DataContext;

namespace Infrastructure.Services;


public class RentalService : ICrudService<Rental>
{
    readonly DapperContext _context;

    public RentalService()
    {
        _context = new DapperContext();
    }

    public List<Rental> GetAll()
    {
        var sql = @"select * from Rentals";
        var res = _context.GetConnection().Query<Rental>(sql).ToList();
        return res;
    }

    public Rental GetById(int id)
    {
        var sql = @"select * from Rentals where RentalId = @Id";
        var res = _context.GetConnection().QueryFirstOrDefault<Rental>(sql, new { Id = id });
        return res;
    }

    public string Add(Rental entity)
    {

        var sqqlCar = "select PricePerDay from Cars where CarId = @CarId";
        decimal pricePerDay = _context.GetConnection().QueryFirstOrDefault<decimal>(sqqlCar, new { CarId = entity.CarId });
        entity.TotalCost = pricePerDay * ((decimal)(entity.EndDate-entity.StartDate).TotalDays);
        var sql = @"insert into Rentals (CarId,CustomerId,StartDate,EndDate,TotalCost) values (@CarId, @CustomerId, @StartDate,@EndDate,@TotalCost) returning RentalId";
        var res = _context.GetConnection().QuerySingle<string>(sql, entity);
        return $"Rental {res} was added";
    }

    public string Update(Rental entity)
    {
        var sql = "update Rentals set CarId=@CarId, CustomerId=@CustomerId, StartDate=@StartDate, EndDate=@EndDate, TotalCost=@TotalCost where RentalId = @RentalId returning RentalId";
        var res = _context.GetConnection().QuerySingle<string>(sql, entity);
        return $"Rental {res} was updated";
    }

    public string Delete(int entity)
    {
        var sql = "delete from Rentals where RentalId = @RentalId";
        var res = _context.GetConnection().QuerySingle<string>(sql, new { RentalId = entity });
        return $"Rental {res} was deleted";
    }

    public List<Rental> SearchCustomerRentals(int customerId)
    {
        var sql = @"select * from Rentals where CustomerId = @CustomerId";
        var res = _context.GetConnection().Query<Rental>(sql, new { CustomerId = customerId }).ToList();
        return res;
    }
}