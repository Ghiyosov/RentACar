using System.Net;
using Dapper;
using Domein.Models;
using Infrastructure.ApiResponse;
using Infrastructure.DataContext;

namespace Infrastructure.Services;


public class RentalService : ICrudService<Rental>
{
    readonly DapperContext _context;

    public RentalService()
    {
        _context = new DapperContext();
    }

    public Response<List<Rental>> GetAll()
    {
        var sql = @"select * from Rentals";
        var res = _context.GetConnection().Query<Rental>(sql).ToList();
        return new Response<List<Rental>>(res);
    }

    public Response<Rental> GetById(int id)
    {
        var sql = @"select * from Rentals where RentalId = @Id";
        var res = _context.GetConnection().QueryFirstOrDefault<Rental>(sql, new { Id = id });
        return new Response<Rental>(res);
    }

    public Response<bool> Add(Rental entity)
    {

        var sqqlCar = "select PricePerDay from Cars where CarId = @CarId";
        decimal pricePerDay = _context.GetConnection().QueryFirstOrDefault<decimal>(sqqlCar, new { CarId = entity.CarId });
        entity.TotalCost = pricePerDay * ((decimal)(entity.EndDate-entity.StartDate).TotalDays);
        var sql = @"insert into Rentals (CarId,CustomerId,StartDate,EndDate,TotalCost) values (@CarId, @CustomerId, @StartDate,@EndDate,@TotalCost) returning RentalId";
        var res = _context.GetConnection().Execute(sql, entity);
        return res == 0
                ? new Response<bool>(HttpStatusCode.InternalServerError, "Internal Server Error")
                : new Response<bool>(HttpStatusCode.OK, "Success");
    }

    public Response<bool> Update(Rental entity)
    {
        var sql = "update Rentals set CarId=@CarId, CustomerId=@CustomerId, StartDate=@StartDate, EndDate=@EndDate, TotalCost=@TotalCost where RentalId = @RentalId;";
        var res = _context.GetConnection().Execute(sql, entity);
        return res == 0
            ? new Response<bool>(HttpStatusCode.InternalServerError, "Internal Server Error")
            : new Response<bool>(HttpStatusCode.OK, "Success");
    }

    public Response<bool> Delete(int entity)
    {
        var sql = "delete from Rentals where RentalId = @RentalId";
        var res = _context.GetConnection().Execute(sql, new { RentalId = entity });
        return res == 0
            ? new Response<bool>(HttpStatusCode.InternalServerError, "Internal Server Error")
            : new Response<bool>(HttpStatusCode.OK, "Success");
    }

    public Response<List<Rental>> SearchCustomerRentals(int customerId)
    {
        var sql = @"select * from Rentals where CustomerId = @CustomerId";
        var res = _context.GetConnection().Query<Rental>(sql, new { CustomerId = customerId }).ToList();
        return new Response<List<Rental>>(res);
    }
}