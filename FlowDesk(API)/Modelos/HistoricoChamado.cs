namespace FlowDesk_API_.Modelos
{
    public class HistoricoChamado
    {
        public Guid Id { get; set; }

        public Guid ChamadoId { get; set; }
        public Chamado Chamado { get; set; } = null!;

        public string AutorId { get; set; } = string.Empty;
        public Usuario Autor { get; set; } = null!;

        public string Evento { get; set; } = string.Empty;

        public string? Antes { get; set; }
        public string? Depois { get; set; }

        public DateTimeOffset CriadoEmUtc { get; set; }
            = DateTimeOffset.UtcNow;
    }
}
