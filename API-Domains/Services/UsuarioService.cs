using API_Domains.DTO.Login;
using API_Domains.DTO.Usuario;
using API_Domains.Indices;
using API_Domains.Interfaces;
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
    private readonly ITokenService _tokenService;

    public UsuarioService(IMapper mapper, IUsuarioRepository usuarioRepository, ITokenService tokenService)
    {
        _mapper = mapper;
        _usuarioRepository = usuarioRepository;
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
        var usuario = await _usuarioRepository.GetUserByEmail(login.Email);

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
