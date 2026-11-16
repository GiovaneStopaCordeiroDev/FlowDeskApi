using System.ComponentModel.DataAnnotations;

namespace FlowDesk_API_.Dtos
{
    public class AtribuirTecnicoDto
    {
        [Required(ErrorMessage = "Adicione um tecnico para atribuir ao chamado")]
        public string TecnicoResponsavelId { get; set; } = string.Empty;
    }
}
