namespace FlowDesk_API_.Exceptions
{
    public class ExcluirChamadoAbertoException: Exception
    {
        public ExcluirChamadoAbertoException(): base("Não é possível excluir um chamado que está aberto.")
        {
            
        }
    }
}
