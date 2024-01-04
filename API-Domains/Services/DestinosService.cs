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
        private readonly IDestinosRepository _destinoRepository;
        private readonly IChatGPTService _chatGPTService;

        public DestinosService(IDestinosRepository desRepository, IChatGPTService chatGPTService)
        {
            _destinoRepository = desRepository;
            _chatGPTService = chatGPTService;
        }

        public async Task<DestinosIndex> CreateDestino(DestinosIndex destino)
        {
            var query = $"Traga uma descrição em dois parágrafos, uma em português e outra em inglês do lugar{destino.Name}";
            var text = await _chatGPTService.ChatGPTConsult(query);
            if (string.IsNullOrEmpty(text))
                throw new Exception("Erro ao cadastrar destino");
            var destinoCreated = await _destinoRepository.CreateDestino(destino);
            return destinoCreated;
        }

        public async Task<bool> DeleteDestino(string id)
        {
            var isDeleted = await _destinoRepository.DeleteDestino(id);
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
            return await _destinoRepository.GetDestinoById(id);
        }

        public async Task<DestinosIndex> UpdateDestino(DestinosIndex destino, string id)
        {
            var destinoAtualizado = await _destinoRepository.UpdateDestino(destino, id);
            return destinoAtualizado;
        }
    }
}
