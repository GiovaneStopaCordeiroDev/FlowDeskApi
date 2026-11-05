using FlowDesk_API_.Modelos;
using static FlowDesk_API_.Modelos.PrioridadeChamadoEnum;

namespace FlowDesk_API_.Dtos
{
    public class LerChamadoDto
    {
        public Guid Id { get; set; }
        public string Clienteid { get; set; }
        public string TecnicoResponsavelId { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public PrioridadeChamado PrioridadeChamado;
    }
}
