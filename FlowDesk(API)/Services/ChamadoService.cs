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

        public async Task<LerChamadoDto> PublicarChamado(CriarChamadoDto dto, string clientId, Guid empresaId)
        {
            Chamado chamado = new Chamado
            {
                Id = Guid.NewGuid(),
                Titulo = dto.Titulo,
                Descricao = dto.Descricao,
                CriadoEmUtc = DateTimeOffset.UtcNow,
                PrioridadeChamado = dto.PrioridadeChamado,
                Clienteid = clientId,
                EmpresaId = empresaId
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
            Chamado? chamado = await _context.Chamados.FirstOrDefaultAsync(c => c.Id == id);

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

        public async Task<List<Chamado>> ListarChamadoPorEmpresa(Guid EmpresaId)
        {
            return await _context.Chamados.Where(c => c.EmpresaId == EmpresaId).ToListAsync();
        }

        public async Task<LerChamadoDto> AtribuirComentario(CriarComentarioDto dto, Guid id)
        {
            Chamado? chamado = await _context.Chamados.FirstOrDefaultAsync(c => c.Id == id);

            if (chamado == null)
            {
                throw new Exception("Chamado nullo");
            }
            var novoComentario = new Comentario
            {
                Id = Guid.NewGuid(),
                AutorId = dto.AutorId,
                ConteudoComentario = dto.ConteudoComentario,
                CriadoEmUtc = DateTimeOffset.UtcNow
            };
            chamado.Comentarios.Add(novoComentario);
            await _context.SaveChangesAsync();

            return new LerChamadoDto
            {
                Id = chamado.Id,
                Titulo = chamado.Titulo,
                Descricao = chamado.Descricao,
                PrioridadeChamado = chamado.PrioridadeChamado,
                Comentarios = chamado.Comentarios.Select(c => new LerComentarioDto
                {
                    Id = c.Id,
                    AutorId = c.AutorId,
                    ConteudoComentario = c.ConteudoComentario,
                    CriadoEmUtc = c.CriadoEmUtc
                }).ToList()
            };
        }

        public async Task DeletarChamado(Guid id)
        {
            Chamado? chamado = await _context.Chamados.FirstOrDefaultAsync(c => c.Id == id);
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
            Chamado? chamado = await _context.Chamados.FirstOrDefaultAsync(c => c.Id == id);
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
            Chamado? chamado = await _context.Chamados.FirstOrDefaultAsync(c => c.Id == id);
            var tecnico = await _context.Users.FirstOrDefaultAsync(t => t.Id == dto.TecnicoResponsavelId);

            if (chamado == null)
            {
                throw new Exception("Não foi possivel encontrar o chamado");
            }
            if(tecnico == null)
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
