using FlowDesk_API_.Modelos;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace FlowDesk_API_.Services
{
    public class TokenService
    {

        public string GenerateToken(Usuario usuario)
        {
            Claim[] claims = new Claim[]
            {
                new Claim("username", usuario.Nome),
                new Claim("id", usuario.Id),
          
        };

            var chave = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("eif349fre9ifr39i544y3f43h43eud4fr38934f9ir9"));

            var signinCredentials = new SigningCredentials(chave, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken
                (
                expires: DateTime.Now.AddMinutes(10),
                claims: claims,
                signingCredentials: signinCredentials
                ); 
            if (usuario.StatusUsuario != StatusUsuario.Ativo)
            {
                return null;
            }

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}