

using AutoMapper;
using JornadaMilhas.Core.DTO.Destinos;
using JornadaMilhas.Core.Entities;

using JornadaMilhas.Core.Interfaces.Destinos;
using JornadaMilhas.Core.Repositories.Interfaces;
using JornadaMilhas.Infrastruture.Persistence.UOW;

namespace JornadaMilhas.Application.Services
{
    public class DestinosService : IDestinosService
    {
        private readonly IMapper _mapper;
        private IRepositoryDestino _destinoRepository;

        public DestinosService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _destinoRepository = unitOfWork.DestinoRepository;
            _mapper = mapper;
        }

        public async Task<Destino> CreateDestino(CreateDestinoDTO destinoDTO)
        {
            var destino = _mapper.Map<Destino>(destinoDTO);
            var destinoCreated = await _destinoRepository.Create(destino);
            return destinoCreated;
        }

        public async Task<bool> DeleteDestino(string id)
        {
            var isDeleted = await _destinoRepository.Delete(id);
            return isDeleted;
        }

        public async Task<IEnumerable<Destino>> GetAllAsync(int page, int size)
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
            var destinoIndex = _mapper.Map<Destino>(destino);
            var destinoAtualizado = await _destinoRepository.Update(destinoIndex, id);
            return destinoAtualizado;
        }
    }
}
