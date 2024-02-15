using API_Domains.DTO.Depoimeto;
using API_Domains.Interfaces;
using API_Domains.Interfaces.Depoimentos;
using API_Infraestrutura.Indices;
using AutoMapper;
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
        private readonly IMapper _mapper;
        

        public DepoimentosService(IDepoimentosRepository depoimentosRepository,IMapper mapper)
        {
            _depoimentosRepository = depoimentosRepository;
            _mapper = mapper;
        }


        public async Task<IEnumerable<DepoimentosIndex>> GetAllDepoimentosAsync(int page, int size)
        {
           var dados = await _depoimentosRepository.GetAllAsync(page, size);

            return dados;
        }

        public async  Task<DepoimentosIndex> CreateDepoimento(DepoimentoDTO depoimentoDTO)
        {
            var depoimento = _mapper.Map<DepoimentosIndex>(depoimentoDTO);
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

        public async Task<bool> UpdateDepoimento(DepoimentoAtualizarDTO depoimentoDTO, string id)
        {
            var depoimento = await GetDepoimentoById(id) ?? throw new Exception("Não existe depoimento");
            var depoimentorRequisicao = _mapper.Map(depoimentoDTO, depoimento);
            return await _depoimentosRepository.Update(depoimentorRequisicao, id);
        }

        public async Task<DepoimentosIndex> GetDepoimentoById(string id)
        {
            return await _depoimentosRepository.GetById(id);
        }
    }
}
