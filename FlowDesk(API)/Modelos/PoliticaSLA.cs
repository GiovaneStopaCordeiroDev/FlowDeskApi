using static FlowDesk_API_.Modelos.PrioridadeChamadoEnum;

namespace FlowDesk_API_.Modelos
{
    public class PoliticaSLA
    {
        public Guid Id { get; set; }

        public Guid EmpresaId { get; set; }
        public Empresa Empresa { get; set; } = null!;

        public PrioridadeChamado Prioridade { get; set; }

        public int MinPrimeiraResposta { get; set; }

        public int MinResolucao { get; set; }
    }
}
