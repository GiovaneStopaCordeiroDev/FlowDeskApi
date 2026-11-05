using FlowDesk_API_.Modelos;
using System.ComponentModel.DataAnnotations;

namespace FlowDesk_API_.Dtos
{
    public class CriarEmpresaDto
    {
        [Required(ErrorMessage = "Adicione um nome a empresa")]
        public required string Nome { get; set; }
        public StatusEmpresaEnum Status = StatusEmpresaEnum.Ativo;
    }
}
