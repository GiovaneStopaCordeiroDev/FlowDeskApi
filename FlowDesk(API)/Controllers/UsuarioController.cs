using FlowDesk_API_.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FlowDesk_API_.Controllers
{
    [ApiController]
    [Route("controller")]
    public class UsuarioController: ControllerBase
    {
        private readonly UsuarioService _usuarioService;

        public UsuarioController(UsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        [Authorize(Roles = "Administrador")]
        [HttpPost("atribuir-perfil")]
        public async Task<IActionResult> AtribuirPerfil(string id, string perfil)
        {

           var resultado = await _usuarioService.AtribuirPerfil(id, perfil);
            if(resultado == null)
            {
                return NotFound("Usuario não encontrado");
            }

            if (!resultado.Succeeded)
            {
                return BadRequest(resultado.Errors);    
            }

            return NoContent();
        }
    }
}
