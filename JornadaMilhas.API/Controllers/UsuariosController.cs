

using JornadaMilhas.Core.DTO.Usuario;
using JornadaMilhas.Core.Interfaces.Usuarios;
using Microsoft.AspNetCore.Mvc;

namespace JornadaMilhas.API;

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
    public async Task<IActionResult> PegarUsuarioPorId(long id)
    {
        var usuario = await _service.GetUsuarioById(id);
        return Ok(usuario);
    }


}
