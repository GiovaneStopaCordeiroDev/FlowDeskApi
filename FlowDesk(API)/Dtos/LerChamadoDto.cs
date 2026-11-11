using FlowDesk_API_.Modelos;
using static FlowDesk_API_.Modelos.PrioridadeChamadoEnum;

namespace FlowDesk_API_.Dtos
{
    public class LerChamadoDto
    {
        public Guid Id { get; set; }
        public string Clienteid { get; set; } = string.Empty;
        public string TecnicoResponsavelId { get; set; } = string.Empty;
        public string Titulo { get; set; } = string.Empty;
        public string Descricao { get; set; } = string.Empty;
        public PrioridadeChamado PrioridadeChamado { get; set; }
        public ICollection<LerComentarioDto> Comentarios { get; set; } = new List<LerComentarioDto>();
    }
}
