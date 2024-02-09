using API_Domains.DTO.Destinos;
using API_Domains.Indices;
using API_Domains.Interfaces.Destinos;
using AutoMapper;

namespace API_Domains.Services
{
    public class DestinosService : IDestinosService
    {
        private readonly IDestinosRepository _destinoRepository;
        private readonly IMapper _mapper;


        public DestinosService(IDestinosRepository desRepository, IMapper mapper)
        {
            _destinoRepository = desRepository;
            _mapper = mapper;
        }

        public async Task<DestinosIndex> CreateDestino(CreateDestinoDTO destinoDTO)
        {
            var destino = _mapper.Map<DestinosIndex>(destinoDTO);
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

        public async Task<IEnumerable<DetailsDestinoDTO>> GetAllAsync(int page, int size)
        {
            return _mapper.Map<IEnumerable<DetailsDestinoDTO>>(await _destinoRepository.GetAllAsync(page, size));
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
