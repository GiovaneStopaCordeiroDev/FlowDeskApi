namespace FlowDesk_API_.Dtos
{
    public class LerComentarioDto
    {

        public Guid Id { get; set; }
        public string AutorId { get; set; } = string.Empty;
        public string ConteudoComentario { get; set; } = string.Empty;
        public DateTimeOffset CriadoEmUtc { get; set; }

    }
}
