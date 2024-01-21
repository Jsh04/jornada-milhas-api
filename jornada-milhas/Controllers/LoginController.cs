
using API_Domains.DTO.Login;
using API_Domains.Interfaces.Usuarios;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace jornada_milhas.Controllers;

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
        var usuarioCredencias = await _usuarioService.LoginUsuario(login);
        return Ok(usuarioCredencias);
    }

}
