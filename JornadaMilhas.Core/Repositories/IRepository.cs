


namespace JornadaMilhas.Core.Repositories;

public interface IRepository<T>
{
    Task<IEnumerable<T>> GetAllAsync(int page, int size, CancellationToken cancellationToken);
    Task<T> CreateAsync(T obj, CancellationToken cancellationToken);
    Task<bool> DeleteAsync (long id, CancellationToken cancellationToken);
    Task<bool> Update(T obj, long id, CancellationToken cancellationToken);
    Task<T> GetByIdAsync(long id, CancellationToken cancellationToken);
}
