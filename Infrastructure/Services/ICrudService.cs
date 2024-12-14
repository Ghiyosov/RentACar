using Infrastructure.ApiResponse;

namespace Infrastructure.Services;

public interface ICrudService<T>
{
    Response<List<T>> GetAll();
    Response<T> GetById(int id);
    Response<bool> Add(T entity);
    Response<bool> Update(T entity);
    Response<bool> Delete(int entity);
}