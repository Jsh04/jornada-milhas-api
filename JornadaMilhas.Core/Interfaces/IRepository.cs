

using Elastic.Clients.Elasticsearch;

namespace JornadaMilhas.Core.Interfaces;

public interface IRepository<T>
{
    Task<IEnumerable<T>> GetAllAsync(int page, int size);
    Task<T> Create(T obj);
    Task<bool> Delete(string id);
    Task<bool> Update(T obj, string id);
    Task<T> GetById(string id);
    Task<T> SearchObjectByQuery(Action<SearchRequestDescriptor<T>> request);
}
