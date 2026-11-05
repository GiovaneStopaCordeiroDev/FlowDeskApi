using System.ComponentModel.DataAnnotations;

namespace FlowDesk_API_.Dtos
{
    public class LoginUsuarioDto
    {
        [Required(ErrorMessage ="Insira o nome de usuario")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "Insira a senha do usuario")]
        public string Senha { get; set; }
    }
}
