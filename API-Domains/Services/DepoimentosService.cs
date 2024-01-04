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
            var depoimentoCriado = await _depoimentosRepository.Create(depoimento);
            return depoimentoCriado;
        }

        public async Task<IEnumerable<DepoimentosIndex>> GetAllAsync(int page, int size)
        {
            return await _depoimentosRepository.GetAllAsync(page, size);
        }

        public async Task<bool> DeleteDepoimento(string id)
        {
            return await  _depoimentosRepository.Delete(id);
        }

        public async Task<DepoimentosIndex> UpdateDepoimento(DepoimentosIndex depoimento, string id)
        {
           return await _depoimentosRepository.Update(depoimento, id);
        }

        public async Task<DepoimentosIndex> GetDepoimentoById(string id)
        {
            return await _depoimentosRepository.GetById(id);
        }
    }
}
