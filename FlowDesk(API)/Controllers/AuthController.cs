using FlowDesk_API_.Dtos;
using FlowDesk_API_.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FlowDesk_API_.Controllers
{
    [ApiController]
    [Route("api/v1/auth")]
    public class AuthController : ControllerBase
    {

        private AuthService _AuthService;
        public AuthController(AuthService AuthService)
        {
            _AuthService = AuthService;
        }

        [HttpPost("registro")]
        public async Task<IActionResult> CadastrarUsuario(CriarUsuarioDto dto)
        {
            var resultado = await _AuthService.CadastrarUsuario(dto);
            if (!resultado.Succeeded)
            {
                return BadRequest(resultado.Errors);
            }
            return Created();
        }

        [HttpPost("login")]
        public async Task<IActionResult> LogarUsuario(LoginUsuarioDto dto)
        {
            var token = await _AuthService.LogarUsuario(dto);
            if(token == null)
            {
                return Unauthorized("Usuário ou senha inválidos.");
            }

            return Ok(token);
        }

        [Authorize(Roles = "Administrador")]
        [HttpGet("teste-admin")]
        public IActionResult TestarAdministrador()
        {
            return Ok("Acesso autorizado!");
        }
    }
}
