namespace FlowDesk_API_.Exceptions
{
    public class AcessoChamadoNegadoException : Exception
    {
        public AcessoChamadoNegadoException() : base("Você não tem permissão para atuar neste chamado.")
        {
        }
    
    }
}
