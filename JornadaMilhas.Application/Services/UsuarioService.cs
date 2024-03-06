


using AutoMapper;
using Elastic.Clients.Elasticsearch;
using JornadaMilhas.Application.Messagings.Senders;
using JornadaMilhas.Core.DTO.Login;
using JornadaMilhas.Core.DTO.Usuario;
using JornadaMilhas.Core.Indices;
using JornadaMilhas.Core.Indices.Enums;
using JornadaMilhas.Core.Interfaces;
using JornadaMilhas.Core.Interfaces.Usuarios;
using JornadaMilhas.Core.Util;

namespace JornadaMilhas.Application.Services;

public class UsuarioService : IUsuarioService
{
    private readonly IMapper _mapper;
    private readonly IRepository<UsuarioIndex> _usuarioRepository;
    private readonly ITokenService _tokenService;
    private readonly SendEmailMessage _message;

    public UsuarioService(IMapper mapper, IUnitOfWork unitOfWork, ITokenService tokenService, SendEmailMessage message)
    {
        _mapper = mapper;
        _usuarioRepository = unitOfWork.UsuarioRepository;
        _tokenService = tokenService;
        _message = message;
    }

    public async Task<DetalhamentoUsuarioDTO> CreateUsuario(UsuarioCadastroDTO usuarioCadastroDTO)
    {
        
        var usuario = _mapper.Map<UsuarioIndex>(usuarioCadastroDTO);
        
        usuario = FormartarCampos(usuario);

        var usuarioCadastrado = await _usuarioRepository.Create(usuario);

        _message.SendConfirmMmail(usuarioCadastrado.Email);
        var usuarioDto = _mapper.Map<DetalhamentoUsuarioDTO>(usuario);
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
        Action<SearchRequestDescriptor<UsuarioIndex>> actions = 
            s => 
            s.Index("usuarios").Query(query => query.Term(t => t.Email.Suffix("keyword"), login.Email));


        var usuario = await _usuarioRepository.SearchObjectByQuery(actions);

        var senhaCriptografada = EncriptarSenha.CriptografarSenha(login.Password);
        
        if (!usuario.Password.Equals(senhaCriptografada))
            throw new Exception("Senha está incorreta");

        var token = _tokenService.GerarToken(usuario);

        var usuarioRetorno = _mapper.Map<DetalhamentoUsuarioDTO>(usuario);

        return new CredenciasUsuarioDTO { User = usuarioRetorno, Token = token };
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
