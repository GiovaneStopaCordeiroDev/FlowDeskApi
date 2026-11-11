using FlowDesk_API_.Modelos;

namespace FlowDesk_API_.Dtos
{
    public class LerEmpresaDto
    {
        public string Nome { get; set; } = string.Empty;
        public StatusEmpresaEnum Status = StatusEmpresaEnum.Ativo;
        public ICollection<Usuario> Usuarios { get; set; } = new List<Usuario>();

    }
}
