using API_Domains.Interfaces;
using API_Infraestrutura.Indices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_Domains.Services
{
    public class DepoimentosService : IDepoimentosService
    {
        private readonly IDepoimentosRepository _depoimentosRepository;

        public DepoimentosService(IDepoimentosRepository depoimentosRepository)
        {

            _depoimentosRepository = depoimentosRepository;

        }

        public Task<IEnumerable<DepoimentosIndex>> GetAllAsync()
        {

            var dados = _depoimentosRepository.GetAllAsync();
            return dados;
        }
    }
}
