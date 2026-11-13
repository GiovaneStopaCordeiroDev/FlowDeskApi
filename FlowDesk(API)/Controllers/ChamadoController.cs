using FlowDesk_API_.Dtos;
using FlowDesk_API_.Modelos;
using FlowDesk_API_.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace FlowDesk_API_.Controllers
{
    [ApiController]
    [Route("api/v1/chamado")]
    public class ChamadoController : ControllerBase
    {

        private ChamadoService _service;
        private readonly UserManager<Usuario> _userManager;
        public ChamadoController(ChamadoService service, UserManager<Usuario> userManager)
        {
            _service = service;
            _userManager = userManager;
        }

        [Authorize]
        [HttpPost("publicaChamado")]
        public async Task<IActionResult> PublicarChamado(CriarChamadoDto dto)
        {
            var user = await _userManager.GetUserAsync(User);

            if (user is null)
                return Unauthorized();

            if (user.EmpresaId is null)
                return Forbid();

            var chamado = await _service.PublicarChamado(dto, user.Id, user.EmpresaId.Value);

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
        public async Task<IActionResult> ListarChamadosPorEmpresa(Guid EmpresaId)
        {
            var listaChamados = await _service.ListarChamadoPorEmpresa(EmpresaId);
            return Ok(listaChamados);
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
