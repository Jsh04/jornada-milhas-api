

using AutoMapper;
using JornadaMilhas.Application.Util;
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
        private IUnitOfWork _unitOfWork;

        public DestinosService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;

            _mapper = mapper;
        }

        public async Task<Destino> CreateDestino(CreateDestinoDTO destinoDTO)
        {
            var destino = _mapper.Map<Destino>(destinoDTO);

            destino.Imagens = ReturnListByteArray(destinoDTO, destino);

            await _unitOfWork.BeginTransactionAsync();
            
            var destinoCreated = await _unitOfWork.DestinoRepository.Create(destino);
            
            await _unitOfWork.CompleteAsync();

            await _unitOfWork.CommitAsync();

            return destinoCreated;
        }

        

        public async Task<bool> DeleteDestino(long id)
        {
            var isDeleted = await _unitOfWork.DestinoRepository.Delete(id);
            return isDeleted;
        }

        public async Task<IEnumerable<Destino>> GetAllAsync(int page, int size)
        {
            var destinos = await _unitOfWork.DestinoRepository.GetAllAsync(page, size);
            return destinos;
        }

        public async Task<DetailsDestinoDTO> GetDestinoById(long id)
        {
            var destinoElastic = await _unitOfWork.DestinoRepository.GetById(id);
            var destinoDto = _mapper.Map<DetailsDestinoDTO>(destinoElastic);
            return destinoDto;
        }

        public async Task<bool> UpdateDestino(UpdateDestinoDTO destino, long id)
        {
            var destinoIndex = _mapper.Map<Destino>(destino);
            var destinoAtualizado = await _unitOfWork.DestinoRepository.Update(destinoIndex, id);
            return destinoAtualizado;
        }

        private List<ImagemDestino> ReturnListByteArray(CreateDestinoDTO destinoDTO, Destino destino)
        {
            List<ImagemDestino> listImgs = new();

            destinoDTO.Pictures.ForEach(fileBase64 => 
            {
                listImgs.Add(new ImagemDestino
                {
                    ImagemBytes = Convert.FromBase64String(fileBase64),
                    Destino = destino,
                    IdDestino = destino.Id
                });
            });

            return listImgs;
        }
    }
}
