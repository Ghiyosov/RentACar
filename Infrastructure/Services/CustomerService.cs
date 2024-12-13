using System.Net;
using Dapper;
using Domein.Models;
using Infrastructure.ApiResponse;
using Infrastructure.DataContext;

namespace Infrastructure.Services;

public class CustomerService:ICrudService<Customer>
{
    readonly DapperContext _context;

    public CustomerService()
    {
        _context = new DapperContext();
    }

    public Response<List<Customer>> GetAll()
    {
        var sql = "select * from Customers";
        var res = _context.GetConnection().Query<Customer>(sql).ToList();
        return new Response<List<Customer>>(res);
    }

    public Response<Customer> GetById(int id)
    {
        var sql = "select * from Customers where CustomerId = @Id";
        var res = _context.GetConnection().QueryFirstOrDefault<Customer>(sql, new { Id = id });
        return new Response<Customer>(res);
    }

    public Response<bool> Add(Customer entity)
    {
        var sql ="insert into Customers (FirstName,LastName,Phone,Email) values (@FirstName, @LastName,  @Phone, @Email)";
        var res = _context.GetConnection().Execute(sql, entity);
        return res == 0
            ? new Response<bool>(HttpStatusCode.InternalServerError, "Internal Server Error")
            : new Response<bool>(HttpStatusCode.Created, "Customer added successfully");
    }

    public Response<bool> Update(Customer entity)
    {
        var sql = "update Customers set FirstName=@FirstName, LastName=@LastName, Phone=@Phone, Email=@Email where CustomerId = @CustomerId";
        var res = _context.GetConnection().Execute(sql, entity);
        return res == 0
            ? new Response<bool>(HttpStatusCode.InternalServerError, "Internal Server Error")
            : new Response<bool>(HttpStatusCode.Created, "Customer updated successfully");
    }

    public Response<bool> Delete(int entity)
    {
        var sql = "delete from Customers where CustomerId = @CustomerId";
        var res = _context.GetConnection().Execute(sql, new { CustomerId = entity });
        return res == 0
            ? new Response<bool>(HttpStatusCode.InternalServerError, "Internal Server Error")
            : new Response<bool>(HttpStatusCode.Created, "Customer deleted successfully");
    }
}