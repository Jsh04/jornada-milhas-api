

using API_Domains.Interfaces.Usuarios;
using JornadaMilhas.Core.DTO.Login;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace JornadaMilhas.API;

[ApiController]
[Route("[controller]")]
public class LoginController : ControllerBase
{
    private readonly IUsuarioService _usuarioService;

    public LoginController(IUsuarioService usuarioService)
    {
        _usuarioService = usuarioService;
    }

    [AllowAnonymous]
    [HttpPost]
    public async Task<IActionResult> LogarUsuario([FromBody] LoginDTO login)
    {
        try
        {
            var usuarioCredencias = await _usuarioService.LoginUsuario(login);
            return Ok(usuarioCredencias);
        }
        catch (Exception ex)
        {
            if (ex is NullReferenceException)
                return NotFound(ex.Message);
            return BadRequest(ex.Message);
        }
        
        
    }

}
