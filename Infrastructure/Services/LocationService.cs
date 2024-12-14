using System.Net;
using Dapper;
using Domein.Models;
using Infrastructure.ApiResponse;
using Infrastructure.DataContext;

namespace Infrastructure.Services;

public class LocationService:ICrudService<Location>
{
    readonly DapperContext _context;

    public LocationService()
    {
        _context = new DapperContext();
    }

    public Response<List<Location>> GetAll()
    {
        var sql = "select * from Locations";
        var res = _context.GetConnection().Query<Location>(sql).ToList();
        return new Response<List<Location>>(res);
    }

    public Response<Location> GetById(int id)
    {
        var sql = "select * from Locations where LocationId = @Id";
        var res = _context.GetConnection().QueryFirstOrDefault<Location>(sql, new { Id = id });
        return new Response<Location>(res);
    }

    public Response<bool> Add(Location entity)
    {
        var sql = "insert into Locations (City,Address) values (@City,@Address)";
        var res = _context.GetConnection().Execute(sql, entity);
        return res == 0
            ? new Response<bool>(HttpStatusCode.InternalServerError,"Internal Server Error")
            : new Response<bool>(HttpStatusCode.OK, "Record Inserted Successfully");
    }

    public Response<bool> Update(Location entity)
    {
        var sql = "update Locations set City = @City, Address=@Address where LocationId = @LocationId;";
        var res = _context.GetConnection().Execute(sql, entity);
        return res == 0
            ? new Response<bool>(HttpStatusCode.InternalServerError,"Internal Server Error")
            : new Response<bool>(HttpStatusCode.OK, "Record Updated Successfully");
    }

    public Response<bool> Delete(int entity)
    {
        var sql = "delete from Locations where LocationId = @LocationId;";
        var res = _context.GetConnection().Execute(sql, new { LocationId = entity });
        return res == 0
            ? new Response<bool>(HttpStatusCode.InternalServerError,"Internal Server Error")
            : new Response<bool>(HttpStatusCode.OK, "Record Deleted Successfully");
    }
}