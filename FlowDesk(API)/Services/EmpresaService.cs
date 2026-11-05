using FlowDesk_API_.Context;
using FlowDesk_API_.Dtos;
using FlowDesk_API_.Modelos;
using Microsoft.AspNetCore.Mvc;

namespace FlowDesk_API_.Services
{
    public class EmpresaService : ControllerBase
    {
        private FlowDeskContext _context;
        public EmpresaService(FlowDeskContext context)
        {
            _context = context;
        }

        public async Task<LerEmpresaDto> CadastraEmpresa(CriarEmpresaDto dto)
        {
            Empresa empresa = new Empresa
            {
                Nome = dto.Nome,
                Status = StatusEmpresaEnum.Ativo

            };

            _context.Add(empresa);
            await _context.SaveChangesAsync();

            return new LerEmpresaDto
            {
                Nome = empresa.Nome,
                Status = empresa.Status
            };
        }


    }
}
