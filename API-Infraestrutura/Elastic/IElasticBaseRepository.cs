using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_Infraestrutura.Elastic
{
    public interface IElasticBaseRepository<T> where T : class
    {

        Task<List<T>> GetAllAsync();
        
    }
}
