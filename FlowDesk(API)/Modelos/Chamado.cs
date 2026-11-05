using static FlowDesk_API_.Modelos.PrioridadeChamadoEnum;
using static FlowDesk_API_.Modelos.StatusChamadoEnum;

namespace FlowDesk_API_.Modelos
{

    public class Chamado
    {

        public Guid Id { get; set; }
        public Guid EmpresaId { get; set; }
        public string Clienteid { get; set; } = string.Empty;
        public string ?TecnicoResponsavelId { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public DateTimeOffset CriadoEmUtc { get; set; }
        public PrioridadeChamado PrioridadeChamado;
        public StatusChamado StatusChamado;



    }


   
}
