﻿
using JornadaMilhas.Core.DTO.Depoimeto;
using JornadaMilhas.Core.Entities;


namespace JornadaMilhas.Core.Interfaces.Depoimentos
{
    public interface IDepoimentosService
    {
        Task<IEnumerable<Depoimento>> GetAllDepoimentosAsync(int page, int size);
        Task<Depoimento> CreateDepoimento(DepoimentoDTO depoimento);
        Task<bool> DeleteDepoimento(string id);
        Task<bool> UpdateDepoimento(DepoimentoAtualizarDTO depoimento, string id);
        Task<Depoimento> GetDepoimentoById(string id);

    }
}
