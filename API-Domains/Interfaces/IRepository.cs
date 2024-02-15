using API_Infraestrutura.Indices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_Domains.Interfaces
{
    public interface IRepository<T>
    {
        Task<IEnumerable<T>> GetAllAsync(int page, int size);
        Task<T> Create(T obj);
        Task<bool> Delete(string id);
        Task<bool> Update(T obj, string id);
        Task<T> GetById(string id);
    }
}
