namespace FlowDesk_API_.Modelos
{
    public class Comentario
    {
        public Guid Id { get; set; }
        public string ConteudoComentario{ get; set; }

        public Guid ChamadoId { get; set; }
        public Chamado Chamado { get; set; }

        public string AutorId { get; set; } = string.Empty;
        public Usuario Autor { get; set; } = null!;

        public DateTimeOffset CriadoEmUtc { get; set; }
       = DateTimeOffset.UtcNow;
    }
}
