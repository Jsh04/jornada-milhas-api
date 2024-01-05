using API_Domains.Indices;
using API_Domains.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_Domains.Services
{
    public class DestinosService : IDestinosService
    {
        private readonly IRepository<DestinosIndex> _destinoRepository;


        public DestinosService(IRepository<DestinosIndex> desRepository)
        {
            _destinoRepository = desRepository;
        }

        public async Task<DestinosIndex> CreateDestino(DestinosIndex destino)
        {
            var destinoCreated = await _destinoRepository.Create(destino);
            return destinoCreated;
        }

        public async Task<bool> DeleteDestino(string id)
        {
            var isDeleted = await _destinoRepository.Delete(id);
            if (!isDeleted)
                throw new Exception("Erro na deleção do documento");
            
            return isDeleted;
        }

        public async Task<IEnumerable<DestinosIndex>> GetAllAsync(int page, int size)
        {
            return await _destinoRepository.GetAllAsync(page, size);
        }

        public async Task<DestinosIndex> GetDestinoById(string id)
        {
            return await _destinoRepository.GetById(id);
        }

        public async Task<DestinosIndex> UpdateDestino(DestinosIndex destino, string id)
        {
            var destinoAtualizado = await _destinoRepository.Update(destino, id);
            return destinoAtualizado;
        }
    }
}
