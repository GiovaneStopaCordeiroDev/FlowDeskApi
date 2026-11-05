using Microsoft.AspNetCore.Identity;

namespace FlowDesk_API_.Modelos
{
    public enum StatusUsuario
    {
        Ativo = 1,
        Desativado = 2
    }
    public class Usuario : IdentityUser
    {
        public string Nome { get; set; }
        public Guid ?EmpresaId { get; set; }
        public Empresa ?Empresa { get; set; }
        public StatusUsuario StatusUsuario { get; set; } = StatusUsuario.Ativo;
    }
}
