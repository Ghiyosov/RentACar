using System.Net;
using Dapper;
using Domein.Models;
using Infrastructure.ApiResponse;
using Infrastructure.DataContext;

namespace Infrastructure.Services;

public class CarService: ICrudService<Car>
{
    
    readonly DapperContext _context;

    public CarService()
    {
        _context = new DapperContext();
    }
    
    public Response<List<Car>> GetAll()
    {
        var sql = "select * from Cars";
        var res = _context.GetConnection().Query<Car>(sql).ToList();
        return new Response<List<Car>>(res);
    }

    public Response<Car> GetById(int id)
    {
        var sql = "select * from Cars where CarId = @Id";
        var res = _context.GetConnection().QueryFirstOrDefault<Car>(sql, new { Id = id });
        return res==null
            ? new Response<Car>(HttpStatusCode.InternalServerError, "Iternal Server Error")
            : new Response<Car>(HttpStatusCode.Created, "Created");
    }

    public Response<bool> Add(Car entity)
    {
        var sql = "insert into Cars (Model, Manufacturer,Year,PricePerDay) values (@Model, @Manufacturer, @Year, @PricePerDay);";
        var res = _context.GetConnection().Execute(sql, entity);
        return res == 0
            ? new Response<bool>(HttpStatusCode.InternalServerError, "Iternal Server Error")
            : new Response<bool>(HttpStatusCode.Created, "Created");
    }

    public Response<bool> Update(Car entity)
    {
        var sql = "update Cars set Model=@Model, Manufacturer=@Manufacturer, Year=@Year, PricePerDay=@PricePerDay where CarId = @CarId";
        var res = _context.GetConnection().Execute(sql, entity);
        return res == 0
            ? new Response<bool>(HttpStatusCode.InternalServerError, "Iternal Server Error")
            : new Response<bool>(HttpStatusCode.OK, "Udated");
    }

    public Response<bool> Delete(int entity)
    {
        var sqlRentals = "select * from Rentals where CarId = @Id";
        var resRental = _context.GetConnection().QueryFirstOrDefault(sqlRentals, new { Id = entity });
        if (resRental is not null)
        {
            var sql = "delete from Cars where CarId = @Id";
            var res = _context.GetConnection().Execute(sql, new { Id = entity });
            return res == 0
                ? new Response<bool>(HttpStatusCode.InternalServerError, "Iternal Server Error")
                : new Response<bool>(HttpStatusCode.OK, "Deleted");
        }
        else return new Response<bool>(HttpStatusCode.InternalServerError, "Car in rentals");
    }
}