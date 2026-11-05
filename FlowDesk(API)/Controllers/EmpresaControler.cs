using FlowDesk_API_.Dtos;
using FlowDesk_API_.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FlowDesk_API_.Controllers
{
    [ApiController]
    [Route("api/v1/empresa")]
    public class EmpresaControler : ControllerBase
    {

        private EmpresaService _empresaService;
        public EmpresaControler(EmpresaService empresaService)
        {
            _empresaService = empresaService;
        }

        [Authorize(Roles = "Administrador")]
        [HttpPost]
        public async Task<IActionResult> CadastraEmpresa(CriarEmpresaDto dto)
        {
            await _empresaService.CadastraEmpresa(dto);
            return Created();
        }
    }
}
