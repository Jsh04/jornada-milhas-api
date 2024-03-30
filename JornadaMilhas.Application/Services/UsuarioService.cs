


using AutoMapper;

using JornadaMilhas.Application.Messagings.Senders;
using JornadaMilhas.Application.Util;
using JornadaMilhas.Core.DTO.Login;
using JornadaMilhas.Core.DTO.Usuario;
using JornadaMilhas.Core.Entities;
using JornadaMilhas.Core.Interfaces;
using JornadaMilhas.Core.Interfaces.Usuarios;

using JornadaMilhas.Core.Repositories.Interfaces;
using JornadaMilhas.Infrastruture.Persistence.UOW;

namespace JornadaMilhas.Application.Services;

public class UsuarioService : IUsuarioService
{
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;
    private readonly ITokenService _tokenService;
    private readonly SendEmailMessage _message;

    public UsuarioService(IMapper mapper, IUnitOfWork unitOfWork, ITokenService tokenService, SendEmailMessage message)
    {
        _mapper = mapper;
        _unitOfWork = unitOfWork;
        _tokenService = tokenService;
        _message = message;
    }

    public async Task<DetalhamentoUsuarioDTO> CreateUsuario(UsuarioCadastroDTO usuarioCadastroDTO)
    {

        var usuario = _mapper.Map<Usuario>(usuarioCadastroDTO);
        
        usuario = FormartarCampos(usuario);

        await _unitOfWork.BeginTransactionAsync();

        var usuarioCadastrado = await _unitOfWork.UsuarioRepository.Create(usuario);

        await _unitOfWork.CompleteAsync();

        await _unitOfWork.CommitAsync();

        _message.SendConfirmMmail(usuarioCadastrado);

        var usuarioDto = _mapper.Map<DetalhamentoUsuarioDTO>(usuario);

        return usuarioDto;
    }

    public async Task<bool> DeleteUsuario(long id)
    {
        var deleted = await _unitOfWork.UsuarioRepository.Delete(id);
        return deleted;
    }

    public async Task<IEnumerable<DetalhamentoUsuarioDTO>> GetAllAsync(int page, int size)
    {
        return _mapper.Map<List<DetalhamentoUsuarioDTO>>(await _unitOfWork.UsuarioRepository.GetAllAsync(page, size));
    }

    public async Task<DetalhamentoUsuarioDTO> GetUsuarioById(long id)
    {
        var usuario = await _unitOfWork.UsuarioRepository.GetById(id);
        var usuarioDto = _mapper.Map<DetalhamentoUsuarioDTO>(usuario);
        return usuarioDto;
    }


    public async Task<CredenciasUsuarioDTO> AuthenticateUser(LoginDTO login)
    {
        var usuario = await _unitOfWork.UsuarioRepository.GetUserByEmail(login.Email);

        var senhaCriptografada = EncriptarSenha.CriptografarSenha(login.Password);
        
        if (!usuario.Password.Equals(senhaCriptografada))
            throw new Exception("Senha está incorreta");

        var token = _tokenService.GerarToken(usuario);

        var usuarioRetorno = _mapper.Map<DetalhamentoUsuarioDTO>(usuario);

        return new CredenciasUsuarioDTO { User = usuarioRetorno, Token = token };
    }

    public Task<DetalhamentoUsuarioDTO> UpdateUsuario(UsuarioAtualizacaoDTO destino, long id)
    {
        throw new NotImplementedException();
    }

    public async Task<bool> VerifyConfirmMail(long id)
    {
        var usuario = await _unitOfWork.UsuarioRepository.GetById(id);
        return usuario.EmailExists;
    }

    public async Task<bool> ConfirmMailUser(long idUser)
    {
        await _unitOfWork.BeginTransactionAsync();

        var usuario = await _unitOfWork.UsuarioRepository.GetById(idUser);

        usuario.EmailExists = true;

        await _unitOfWork.CompleteAsync();

        await _unitOfWork.CommitAsync();

        return usuario.EmailExists;
    }

    private static Usuario FormartarCampos(Usuario usuario)
    {
        usuario.Password = EncriptarSenha.CriptografarSenha(usuario.Password);
        usuario.Phone = Formatar.RetirarMascara(usuario.Phone);
        usuario.Cpf = Formatar.RetirarMascara(usuario.Cpf);
        return usuario;
    }

    
}
