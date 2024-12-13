using Dapper;
using Domein.Models;
using Infrastructure.DataContext;

namespace Infrastructure.Services;

public class LocationService:ICrudService<Location>
{
    readonly DapperContext _context;

    public LocationService()
    {
        _context = new DapperContext();
    }

    public List<Location> GetAll()
    {
        var sql = "select * from Locations";
        var res = _context.GetConnection().Query<Location>(sql).ToList();
        return res;
    }

    public Location GetById(int id)
    {
        var sql = "select * from Locations where LocationId = @Id";
        var res = _context.GetConnection().QueryFirstOrDefault<Location>(sql, new { Id = id });
        return res;
    }

    public string Add(Location entity)
    {
        var sql = "insert into Locations (City,Address) values (@City,@Address) returning City||' '||Address";
        var res = _context.GetConnection().QuerySingle<string>(sql, entity);
        return $"Location city {res} was added";
    }

    public string Update(Location entity)
    {
        var sql = "update Locations set City = @City, Address=@Address where LocationId = @LocationId returning LocationId";
        var res = _context.GetConnection().QuerySingle<string>(sql, entity);
        return $"Location {res} was updated";
    }

    public string Delete(int entity)
    {
        var sql = "delete from Locations where LocationId = @LocationId returning City||' '||Address";
        var res = _context.GetConnection().QuerySingle<string>(sql, new { LocationId = entity });
        return $"Location {res} was deleted";
    }
}