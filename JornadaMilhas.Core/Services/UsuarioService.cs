
using API_Domains.Interfaces.Usuarios;
using AutoMapper;
using Elastic.Clients.Elasticsearch;
using JornadaMilhas.Core.DTO.Login;
using JornadaMilhas.Core.DTO.Usuario;
using JornadaMilhas.Core.Indices;
using JornadaMilhas.Core.Interfaces;
using JornadaMilhas.Core.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_Domains.Services;

public class UsuarioService : IUsuarioService
{
    private readonly IMapper _mapper;
    private readonly ITokenService _tokenService;
    private readonly IRepository<UsuarioIndex> _usuarioRepository;

    public UsuarioService(IMapper mapper, IUnitOfWork unitOfWork , ITokenService tokenService)
    {
        _mapper = mapper;
        _usuarioRepository = unitOfWork.UsuarioRepository;
        _tokenService = tokenService;
    }

    public async Task<DetalhamentoUsuarioDTO> CreateUsuario(UsuarioCadastroDTO usuarioCadastroDTO)
    {
        var usuario = _mapper.Map<UsuarioIndex>(usuarioCadastroDTO);
        usuario = FormartarCampos(usuario);
        var usuarioCadastrado = await _usuarioRepository.Create(usuario);
        var usuarioDto = _mapper.Map<DetalhamentoUsuarioDTO>(usuarioCadastrado);
        return usuarioDto;
    }

    public async Task<bool> DeleteUsuario(string id)
    {
        var deleted = await _usuarioRepository.Delete(id);
        return deleted;
    }

    public async Task<IEnumerable<DetalhamentoUsuarioDTO>> GetAllAsync(int page, int size)
    {
        return _mapper.Map<List<DetalhamentoUsuarioDTO>>(await _usuarioRepository.GetAllAsync(page, size));
    }

    public async Task<DetalhamentoUsuarioDTO> GetUsuarioById(string id)
    {
        var usuario = await _usuarioRepository.GetById(id);
        var usuarioDto = _mapper.Map<DetalhamentoUsuarioDTO>(usuario);
        return usuarioDto;
    }

    public async Task<CredenciasUsuarioDTO> LoginUsuario(LoginDTO login)
    {
        Action<SearchRequestDescriptor<UsuarioIndex>> actions = s =>
            s.Index("usuarios")
            .Query(
                query =>
                query.Term(t => t.Email.Suffix("keyword"), login.Email));
        var usuario = await _usuarioRepository.SearchObjectByQuery(actions);

        var senhaCriptografada = EncriptarSenha.CriptografarSenha(login.Password);
        
        if (!usuario.Password.Equals(senhaCriptografada))
            throw new Exception("Senha está incorreta");

        var token = _tokenService.GerarToken(usuario);

        var usuarioRetorno = _mapper.Map<DetalhamentoUsuarioDTO>(usuario);

        return new CredenciasUsuarioDTO { Usuario = usuarioRetorno, Token = token };
    }

    public Task<DetalhamentoUsuarioDTO> UpdateUsuario(UsuarioAtualizacaoDTO destino, string id)
    {
        throw new NotImplementedException();
    }

    private static UsuarioIndex FormartarCampos(UsuarioIndex usuario)
    {
        usuario.Password = EncriptarSenha.CriptografarSenha(usuario.Password);
        usuario.Phone = Formatar.RetirarMascara(usuario.Phone);
        usuario.Cpf = Formatar.RetirarMascara(usuario.Cpf);
        return usuario;
    }
}
