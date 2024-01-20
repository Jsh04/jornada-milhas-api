using API_Domains.DTO.Login;
using API_Domains.DTO.Usuario;
using API_Domains.Interfaces.Usuarios;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace jornada_milhas.Controllers;

[Route("[controller]")]
[ApiController]
public class UsuariosController : ControllerBase
{
    private readonly IUsuarioService _service;

    public UsuariosController(IUsuarioService service)
    {
        _service = service;
    }

    [HttpPost]
    public async Task<IActionResult> CadastrarUsuario([FromBody] UsuarioCadastroDTO usuarioCadastroDTO)
    {
        var usuario = await _service.CreateUsuario(usuarioCadastroDTO);
        return CreatedAtAction(nameof(PegarUsuarioPorId), new { id = usuario.Id }, usuario);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> PegarUsuarioPorId(string id)
    {
        var usuario = await _service.GetUsuarioById(id);
        return Ok(usuario);
    }

    [HttpPost("login")]
    public async Task<IActionResult> LoginTeste(LoginDTO login)
    {
        await _service.LoginUsuario(login);
        return Ok();
    }

}
