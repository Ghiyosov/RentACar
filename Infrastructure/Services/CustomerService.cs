using Dapper;
using Domein.Models;
using Infrastructure.DataContext;

namespace Infrastructure.Services;

public class CustomerService:ICrudService<Customer>
{
    readonly DapperContext _context;

    public CustomerService()
    {
        _context = new DapperContext();
    }

    public List<Customer> GetAll()
    {
        var sql = "select * from Customers";
        var res = _context.GetConnection().Query<Customer>(sql).ToList();
        return res;
    }

    public Customer GetById(int id)
    {
        var sql = "select * from Customers where CustomerId = @Id";
        var res = _context.GetConnection().QueryFirstOrDefault<Customer>(sql, new { Id = id });
        return res;
    }

    public string Add(Customer entity)
    {
        var sql ="insert into Customers (FirstName,LastName,Phone,Email) values (@FirstName, @LastName,  @Phone, @Email) returning FirstName";
        var res = _context.GetConnection().QuerySingle<string>(sql, entity);
        return $"Customer {res} was added";
    }

    public string Update(Customer entity)
    {
        var sql = "update Customers set FirstName=@FirstName, LastName=@LastName, Phone=@Phone, Email=@Email where CustomerId = @CustomerId returning CustomerId";
        var res = _context.GetConnection().QuerySingle<string>(sql, entity);
        return $"Customer {res} was updated";
    }

    public string Delete(int entity)
    {
        var sql = "delete from Customers where CustomerId = @CustomerId returning CustomerId";
        var res = _context.GetConnection().QuerySingle<string>(sql, new { CustomerId = entity });
        return $"Customer {res} was deleted";
    }
}