using API_Domains.DTO.Usuario;
using API_Domains.Indices;
using API_Domains.Interfaces.Usuarios;
using API_Domains.Util;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_Domains.Services;

public class UsuarioService : IUsuarioService
{
    private readonly IMapper _mapper;
    private readonly IUsuarioRepository _usuarioRepository;


    public UsuarioService(IMapper mapper, IUsuarioRepository usuarioRepository)
    {
        _mapper = mapper;
        _usuarioRepository = usuarioRepository;
    }

    public async Task<UsuarioIndex> CreateUsuario(UsuarioCadastroDTO usuarioCadastroDTO)
    {
        var usuario = _mapper.Map<UsuarioIndex>(usuarioCadastroDTO);
        usuario = FormartarCampos(usuario);
        var usuarioCadastrado = await _usuarioRepository.Create(usuario);
        return usuarioCadastrado;
    }

    private static UsuarioIndex FormartarCampos(UsuarioIndex usuario)
    {
        usuario.Password = EncriptarSenha.CriptografarSenha(usuario.Password);
        usuario.Phone = Formatar.RetirarMascara(usuario.Phone);
        usuario.Cpf = Formatar.RetirarMascara(usuario.Cpf);
        return usuario;
    }

    public Task<bool> DeleteDestino(string id)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<UsuarioIndex>> GetAllAsync(int page, int size)
    {
        throw new NotImplementedException();
    }

    public Task<UsuarioIndex> GetDestinoById(string id)
    {
        throw new NotImplementedException();
    }

    public Task<UsuarioIndex> UpdateDestino(UsuarioAtualizacaoDTO destino, string id)
    {
        throw new NotImplementedException();
    }
}
