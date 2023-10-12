using API_Domains.Interfaces;
using API_Infraestrutura.Indices;
using System;
using System.Collections;
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


        public async Task<IEnumerable<DepoimentosIndex>> GetAllDepoimentosAsync(int page, int size)
        {
           var dados = await _depoimentosRepository.GetAllAsync(page, size);

            return dados;
        }

        public async  Task<DepoimentosIndex> CreateDepoimento(DepoimentosIndex depoimento)
        {
            var depoimentoCriado = await _depoimentosRepository.CreateDepoimento(depoimento);
            return depoimentoCriado;
        }

        public Task<IEnumerable<DepoimentosIndex>> GetAllDepoimentosAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<bool> DeleteDepoimento(string id)
        {
            return await  _depoimentosRepository.DeleteDepoimento(id);
        }

        public async Task<DepoimentosIndex> UpdateDepoimento(DepoimentosIndex depoimento, string id)
        {
           return await _depoimentosRepository.UpdateDepoimento(depoimento, id);
        }

        public async Task<DepoimentosIndex> GetDepoimentoById(string id)
        {
            return await _depoimentosRepository.GetDepoimentoById(id);
        }
    }
}
