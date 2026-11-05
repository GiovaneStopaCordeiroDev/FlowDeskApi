namespace FlowDesk_API_.Modelos
{

    public class Empresa
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public int Codigo { get; set; }
        public StatusEmpresaEnum Status = StatusEmpresaEnum.Ativo;
        public ICollection<Usuario> Usuarios { get; set; } = new List<Usuario>();
        
    }
}
