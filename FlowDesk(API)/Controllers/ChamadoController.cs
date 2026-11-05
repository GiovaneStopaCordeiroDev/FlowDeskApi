using FlowDesk_API_.Dtos;
using FlowDesk_API_.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FlowDesk_API_.Controllers
{
    [ApiController]
    [Route("api/v1/chamado")]
    public class ChamadoController : ControllerBase
    {

        private ChamadoService _service;

        public ChamadoController(ChamadoService service)
        {
            _service = service;
        }


        [HttpPost("publicaChamado")]
        public async Task<IActionResult> PublicarChamado(CriarChamadoDto dto)
        {
            await _service.PublicarChamado(dto);
            return Created();
        }

        [Authorize(Roles = "Gestor, Tecnico")]
        [HttpPost("adicionaComentario")]
        public IActionResult AdicionarComentario()
        {
            return Created();
        }

        [Authorize]
        [HttpGet("listaChamado")]
        public IActionResult ListarChamados()
        {
            return Ok();
        }

        [Authorize]
        [HttpGet("{id}/listarporid")]
        public IActionResult ListarChamadoPorId()
        {
            return Ok();
        }

        [Authorize(Roles = "Gestor,Tecnico,Administrador")]
        [HttpGet("listaHistorico")]
        public IActionResult ListarHistorico()
        {
            return Ok();
        }

        [Authorize(Roles = "Gestor")]
        [HttpPatch("{id}/atribuir")]
        public IActionResult AtribuirTecnico()
        {
            return Ok();
        }

        [Authorize(Roles = "Gestor")]
        [HttpPatch("{id}/status")]
        public IActionResult GerenciarStatus()
        {
            return NoContent();
        }

        [Authorize(Roles = "Gestor, Tecnico")]
        [HttpDelete("{id}")]
        public IActionResult DeletarChamado()
        {
            return NoContent();
        }
    }
}
