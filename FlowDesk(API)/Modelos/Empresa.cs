namespace FlowDesk_API_.Modelos
{

    public class Empresa
    {
        public Guid Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public int Codigo { get; set; }
        public StatusEmpresaEnum Status { get; set; } = StatusEmpresaEnum.Ativo;
        public ICollection<Usuario> Usuarios { get; set; } = new List<Usuario>();
        
    }
}
