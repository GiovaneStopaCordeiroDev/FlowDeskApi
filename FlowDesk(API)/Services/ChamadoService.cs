using FlowDesk_API_.Context;
using FlowDesk_API_.Dtos;
using FlowDesk_API_.Modelos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using static FlowDesk_API_.Modelos.StatusChamadoEnum;

namespace FlowDesk_API_.Services
{
    public class ChamadoService
    {

        private FlowDeskContext _context;
        public ChamadoService(FlowDeskContext context)
        {
            _context = context;
        }

        public async Task<LerChamadoDto> PublicarChamado(CriarChamadoDto dto)
        {
            Chamado chamado = new Chamado
            {
                Id = Guid.NewGuid(),
                Titulo = dto.Titulo,
                Descricao = dto.Descricao,
                CriadoEmUtc = DateTimeOffset.UtcNow,
                PrioridadeChamado = dto.PrioridadeChamado
            };
            _context.Add(chamado);
            await _context.SaveChangesAsync();
            return new LerChamadoDto
            {
                Id = chamado.Id,
                Titulo = chamado.Titulo,
                Descricao = chamado.Descricao,
                PrioridadeChamado = chamado.PrioridadeChamado
            };
        }

        public async Task<List<Chamado>> ListarChamados()
        {
            List<Chamado> chamado = await _context.Chamados.ToListAsync();
            return chamado;
        }

        public async Task<LerChamadoDto> ListarChamadoPorId(Guid id)
        {
            Chamado chamado = await _context.Chamados.FirstOrDefaultAsync(c => c.Id == id);

            if(chamado == null)
            {
                throw new Exception("Chamado nullo");
            }

            return new LerChamadoDto
            {
                Id = chamado.Id,
                Titulo = chamado.Titulo,
                Descricao = chamado.Descricao,
                PrioridadeChamado = chamado.PrioridadeChamado
            };
        }

        public async Task DeletarChamado(Guid id)
        {
            Chamado chamado = await _context.Chamados.FirstOrDefaultAsync(c => c.Id == id);
            if (chamado == null)
            {
                throw new Exception("Não foi possivel encontrar o chamado");
            }
            if(chamado.StatusChamado == StatusChamado.Aberto)
            {
                throw new Exceptions.ExcluirChamadoAbertoException();
            }
            _context.Remove(chamado);
            await _context.SaveChangesAsync();
        }

        public async Task<LerChamadoDto> AlterarStatus(AlterarChamadoDto dto, Guid id)
        {
            Chamado chamado = await _context.Chamados.FirstOrDefaultAsync(c => c.Id == id);
            if (chamado == null)
            {
                throw new Exception("Não foi possivel encontrar o chamado");
            }

            chamado.StatusChamado = dto.StatusChamado;
            _context.Update(chamado);

            await _context.SaveChangesAsync();

            return new LerChamadoDto
            {
                Id = chamado.Id,
                Titulo = chamado.Titulo,
                Descricao = chamado.Descricao,
                PrioridadeChamado = chamado.PrioridadeChamado
            };
        }

        public async Task<LerChamadoDto> AtribuirTecnico(AlterarChamadoDto dto, Guid id)
        {
            Chamado chamado = await _context.Chamados.FirstOrDefaultAsync(c => c.Id == id);

            if(chamado == null)
            {
                throw new Exception("Não foi possivel encontrar o chamado");
            }
            if(chamado.TecnicoResponsavelId == null)
            {
                throw new Exception("Não foi possivel encontrar o tecnico pesquisado");
            }

            chamado.TecnicoResponsavelId = dto.TecnicoResponsavelId; 

            await _context.SaveChangesAsync();

            return new LerChamadoDto
            {
                Titulo = chamado.Titulo,
                TecnicoResponsavelId = chamado.TecnicoResponsavelId
            };


        }

    }
}
