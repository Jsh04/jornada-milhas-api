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
            return isDeleted;
        }

        public async Task<IEnumerable<DestinosIndex>> GetAllAsync(int page, int size)
        {
            var destinos = await _destinoRepository.GetAllAsync(page, size);
            return destinos;
        }

        public async Task<DetailsDestinoDTO> GetDestinoById(string id)
        {
            var destinoElastic = await _destinoRepository.GetById(id);
            var destinoDto = _mapper.Map<DetailsDestinoDTO>(destinoElastic);
            return destinoDto;
        }

        public async Task<bool> UpdateDestino(UpdateDestinoDTO destino, string id)
        {
            var destinoIndex = _mapper.Map<DestinosIndex>(destino);
            var destinoAtualizado = await _destinoRepository.Update(destinoIndex, id);
            return destinoAtualizado;
        }
    }
}
