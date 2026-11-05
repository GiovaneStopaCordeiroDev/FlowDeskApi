using FlowDesk_API_.Modelos;
using System.ComponentModel.DataAnnotations;
using static FlowDesk_API_.Modelos.PrioridadeChamadoEnum;
using static FlowDesk_API_.Modelos.StatusChamadoEnum;

namespace FlowDesk_API_.Dtos
{
    public class CriarChamadoDto
    {
        [Required(ErrorMessage = "Adicione um titulo para criar o chamado")]
        public required string Titulo { get; set; }
        [Required(ErrorMessage = "Adicione uma descrição para criar o chamado")]
        public required string Descricao { get; set; }
        public PrioridadeChamado PrioridadeChamado;
        public StatusChamado StatusChamado = StatusChamado.Aberto;
    }
}
