using FlowDesk_API_.Modelos;
using System.ComponentModel.DataAnnotations;

namespace FlowDesk_API_.Dtos
{
    public class CriarUsuarioDto
    {
        [Required(ErrorMessage ="Adicione o nome de usuário para o cadastro")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Adicione sua senha de usuário para o cadastro")]
        public string Senha { get; set; }
    }

}
