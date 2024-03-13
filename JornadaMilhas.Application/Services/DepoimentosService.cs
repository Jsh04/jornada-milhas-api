
using AutoMapper;
using JornadaMilhas.Core.DTO.Depoimeto;
using JornadaMilhas.Core.Entities;
using JornadaMilhas.Core.Indices;
using JornadaMilhas.Core.Interfaces;
using JornadaMilhas.Core.Interfaces.Depoimentos;
using JornadaMilhas.Infrastruture.Persistence.UOW;


namespace JornadaMilhas.Application.Services
{
    public class DepoimentosService : IDepoimentosService
    {
        private IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        

        public DepoimentosService(IUnitOfWork unitOfWork ,IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }


        public async Task<IEnumerable<Depoimento>> GetAllDepoimentosAsync(int page, int size)
        {
           var dados = await _unitOfWork.DepoimentoRepository.GetAllAsync(page, size);

            return dados;
        }

        public async  Task<Depoimento> CreateDepoimento(DepoimentoDTO depoimentoDTO)
        {
            var depoimento = _mapper.Map<Depoimento>(depoimentoDTO);
            var depoimentoCriado = await _unitOfWork.DepoimentoRepository.Create(depoimento);
            return depoimentoCriado;
        }

        public async Task<IEnumerable<Depoimento>> GetAllAsync(int page, int size)
        {
            return await _unitOfWork.DepoimentoRepository.GetAllAsync(page, size);
        }

        public async Task<bool> DeleteDepoimento(string id)
        {
            return await _unitOfWork.DepoimentoRepository.Delete(id);
        }

        public async Task<bool> UpdateDepoimento(DepoimentoAtualizarDTO depoimentoDTO, string id)
        {
            var depoimento = await GetDepoimentoById(id) ?? throw new Exception("Não existe depoimento");
            var depoimentorRequisicao = _mapper.Map(depoimentoDTO, depoimento);
            return await _unitOfWork.DepoimentoRepository.Update(depoimentorRequisicao, id);
        }

        public async Task<Depoimento> GetDepoimentoById(string id)
        {
            return await _unitOfWork.DepoimentoRepository.GetById(id);
        }
    }
}
