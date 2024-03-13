


namespace JornadaMilhas.Core.Repositories;

public interface IRepository<T>
{
    Task<IEnumerable<T>> GetAllAsync(int page, int size);
    Task<T> Create(T obj);
    Task<bool> Delete(long id);
    Task<bool> Update(T obj, long id);
    Task<T> GetById(long id);
}
