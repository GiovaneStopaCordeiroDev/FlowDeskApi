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
            var listaChamados = _service.ListarChamados();
            return Ok(listaChamados);
        }

        [Authorize]
        [HttpGet("{id}/listarporid")]
        public IActionResult ListarChamadoPorId(Guid id)
        {
            var chamado = _service.ListarChamadoPorId(id);
            return Ok(chamado);
        }

        [Authorize(Roles = "Gestor,Tecnico,Administrador")]
        [HttpGet("listaHistorico")]
        public IActionResult ListarHistorico()
        {
            return Ok();
        }

        [Authorize(Roles = "Gestor")]
        [HttpPatch("{id}/atribuir")]
        public IActionResult AtribuirTecnico(AlterarChamadoDto dto, Guid id)
        {
            var atribuirTecnico = _service.AtribuirTecnico(dto, id);
            return Ok(atribuirTecnico);
        }

        [Authorize(Roles = "Gestor")]
        [HttpPatch("{id}/status")]
        public IActionResult AlterarStatus(AlterarChamadoDto dto, Guid id)
        {
            var alterarStatus = _service.AlterarStatus(dto, id);
            return NoContent();
        }

        [Authorize(Roles = "Gestor, Tecnico")]
        [HttpDelete("{id}")]
        public IActionResult DeletarChamado(Guid id)
        {
            var chamado = _service.DeletarChamado(id);
            return NoContent();
        }
    }
}
