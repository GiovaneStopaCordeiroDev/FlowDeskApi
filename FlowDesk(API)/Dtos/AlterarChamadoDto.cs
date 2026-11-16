using FlowDesk_API_.Modelos;
using System.ComponentModel.DataAnnotations;
using static FlowDesk_API_.Modelos.PrioridadeChamadoEnum;
using static FlowDesk_API_.Modelos.StatusChamadoEnum;

namespace FlowDesk_API_.Dtos
{
    public class AlterarChamadoDto
    {
        public Guid Id { get; set; }
        public  string Titulo { get; set; } = string.Empty;
        public string? TecnicoResponsavelId { get; set; }
        public  string Descricao { get; set; } = string.Empty;
        public PrioridadeChamado PrioridadeChamado { get; set; }
        public StatusChamado StatusChamado { get; set; } = StatusChamado.Aberto;
    }
}
