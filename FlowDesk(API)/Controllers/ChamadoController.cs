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
            var chamado = await _service.PublicarChamado(dto);
            return Created();
        }

        [Authorize(Roles = "Gestor, Tecnico")]
        [HttpPost("adicionaComentario")]
        public async Task<IActionResult> AtribuirComentario(CriarComentarioDto dto, Guid id)
        {
            var comentario = await _service.AtribuirComentario(dto, id);
            return Created();
        }

        [Authorize]
        [HttpGet("listaChamado")]
        public async Task<IActionResult> ListarChamados()
        {
            var listaChamados = await _service.ListarChamados();
            return Ok(listaChamados);
        }

        [Authorize]
        [HttpGet("listaChamadoPorEmpresa")]
        public async Task<IActionResult> ListarChamadosPorEmpresa()
        {
            return Ok();
        }

        [Authorize]
        [HttpGet("{id}/listarporid")]
        public async Task<IActionResult> ListarChamadoPorId(Guid id)
        {
            var chamado = await _service.ListarChamadoPorId(id);
            return Ok(chamado);
        }

        [Authorize(Roles = "Gestor")]
        [HttpPatch("{id}/atribuir")]
        public async Task<IActionResult> AtribuirTecnico(AlterarChamadoDto dto, Guid id)
        {
            var atribuirTecnico = await _service.AtribuirTecnico(dto, id);
            return Ok(atribuirTecnico);
        }

        [Authorize(Roles = "Gestor")]
        [HttpPatch("{id}/status")]
        public async Task<IActionResult> AlterarStatus(AlterarChamadoDto dto, Guid id)
        {
            var alterarStatus = await _service.AlterarStatus(dto, id);
            return NoContent();
        }

        [Authorize(Roles = "Gestor, Tecnico")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletarChamado(Guid id)
        {
            var chamado = _service.DeletarChamado(id);
            return NoContent();
        }
    }
}
